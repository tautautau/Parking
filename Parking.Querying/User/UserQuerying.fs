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
    let car2 =
        {
            Id= Guid.NewGuid();
            Plate= "NEJ526";
            Make= "Honda";
            Model= "Cvic"
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

    let userDto2 = 
        {
            Id= Guid.NewGuid();
            CognizantId= "654321";
            Name= "Peter";
            Surname= "Pen";
            Email= "Peter.Pen@mail.com";
            Car=cars;
        }
    let users = [|userDto; userDto2|]


    type UserReadFacade() =
        interface IUserReadFacade with
            
            member x.GetUserByCognizantId(arg1: CognizantId.T): UserDto = 
                userDto

            member x.GetUsers: UserDto [] = 
                users  
