namespace Parking.Web.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http

open Parking.Domain.User.UserQueries
open Parking.Domain.User.UserDomain

open Parking.Infrastructure.FunctionChaining


[<Route("api/[controller]")>]
type UserController(userReadFacade: IUserReadFacade) =
    inherit Controller()
    member x.UserReadFacade =  userReadFacade 

    /// Gets all values.
    [<HttpGet>]
    member x.Get() = userReadFacade.GetUsers

    [<HttpGet("{id}", Name = "Get by user by cognizant id")>]
    member x.GetById(id: string): IActionResult =
        match CognizantId.create id with
        | Success s -> x.Ok(userReadFacade.GetUserByCognizantId s):> _
        | Failure f -> x.BadRequest(f) :> _
