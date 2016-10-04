namespace Parking.Domain.Admin

open System
open Parking.Infrastructure.Messages

module UserCommands = 
    type CreateUserCommand(name: String) =
        inherit Command()        
        member this.Name = name