namespace Parking.Querying.User

open System

open Parking.Domain.User.UserQueries
open Parking.Domain.User.UserDomain

module UserQuerying = 

    let car =
        {
            Id= Guid.NewGuid();
            Plate= "NEJ526";
            Make= "Subaru";
            Model= "Impreza WRX"
        }
    let cars = [|car|]
    let userDto = 
        {
            Id= Guid.NewGuid();
            CognizantId= "123456";
            Name= "Johnny";
            Surname= "Bravo";
            Email= "johnny.bravo@mail.com";
            Car=cars;
        }

    let users = [|userDto|]

    type IAddingService =
        abstract member Add: int

    type MyAddingService() =
        
        interface IAddingService with 
            member this.Add = 
                55


    type UserReadFacade() =

        //interface IUserReadFacade with 
            member this.GetUserByCognizantId (cognizantId: CognizantId.T) = 
                userDto
                
        //interface IUserReadFacade with 
            member this.GetUsers =
                users
