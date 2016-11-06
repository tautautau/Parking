namespace Parking.Querying

open System
open Microsoft.Extensions.DependencyInjection

open Parking.Domain.User.UserQueries
open Parking.Querying.User.UserQuerying

type Bootstrap = 
    static member Setup(services: IServiceCollection) =
        printfn "Configuring services..."
        services
            .AddSingleton<IUserReadFacade, UserReadFacade>()
            |> ignore