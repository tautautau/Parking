namespace Parking.Persistance.User

open System

open Parking.Infrastructure.Messages
open Parking.Domain.User.UserCommands

module UserHandlers = 
    type CreateUserCommandHandler() =
        interface ICommandHandler<CreateBasicUserCommand> with
            member x.Handle(command: CreateBasicUserCommand): unit = 
                 ()
