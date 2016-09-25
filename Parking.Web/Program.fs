
open System
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging

open Parking.Web

[<EntryPoint>]
let main argv = 
    printfn "Starting server..."
    let host = 
        WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()     
            .UseStartup<Startup>()
            .Build()

    host.Run()
    printfn "Server finished!"
    0