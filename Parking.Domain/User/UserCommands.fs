namespace Parking.Domain.User

open System

open Parking.Infrastructure.Messages
open Parking.Domain.User.UserDomain

module UserCommands = 
    type CreateBasicUserCommand(user: User.T) =
        inherit Command()        
        member this.User = user