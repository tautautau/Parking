namespace Parking.Web

open System
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.FileProviders

type Startup = 
    val private Configuration : IConfigurationRoot    
    new(env: IHostingEnvironment) =
        printfn "Intializing Startup..."     
        let appSeetingEnvironment = sprintf "appsettings.%s.json" env.EnvironmentName
        let builder = 
            ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile(appSeetingEnvironment, true)                
                .AddEnvironmentVariables()        

        if env.IsDevelopment() 
        then 
            builder.AddApplicationInsightsSettings(Nullable<bool>(true)) 
            |> ignore
        else ()

        {Configuration = builder.Build()}
        
    member this.ConfigureServices(services: IServiceCollection) =
        printfn "Configuring services..."
        services
            .AddApplicationInsightsTelemetry(this.Configuration)
            .AddMvc() 
            |> ignore
        
    member this.Configure(app: IApplicationBuilder, env:IHostingEnvironment, loggerFactory: ILoggerFactory) =
        printfn "Configuring app.."
        this.SetupLogging loggerFactory

        this.SetupExceptionHandling(app, env)

        this.SetupRouting(app, env)

    
    member private this.SetupLogging(loggerFactory: ILoggerFactory) =
        loggerFactory
            .AddConsole(this.Configuration.GetSection("Logging"))
            .AddDebug()
            |> ignore
        
    member private this.SetupExceptionHandling(app: IApplicationBuilder, env:IHostingEnvironment) =
        if env.IsDevelopment() 
            then 
                app
                    .UseDeveloperExceptionPage()
                    .UseBrowserLink()
                    |> ignore
            else
                app.UseExceptionHandler("/Home/Error") 
                |> ignore


    member private this.SetupRouting(app: IApplicationBuilder, env:IHostingEnvironment) =
        let nodeModules = "node_modules"
        let fileOptions = new StaticFileOptions(FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, nodeModules)), RequestPath = PathString(sprintf "/%s" nodeModules))        

        app
            .UseApplicationInsightsRequestTelemetry()
            .UseApplicationInsightsExceptionTelemetry()
            .UseDefaultFiles()
            .UseStaticFiles()
            .UseStaticFiles(fileOptions)
            .UseMvc(
                fun routes -> 
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}") 
                |> ignore )
            |> ignore 