namespace Parking.Domain.Admin

open System
open Parking.Infrastructure.Messages

module AdminCommands = 
    type CreateUserCommand(name: String) =
        inherit Command()        
        member this.Name = name