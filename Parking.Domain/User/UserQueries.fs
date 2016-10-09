namespace Parking.Domain.User

open System

open Parking.Domain.User.UserDomain


module UserQueries =
    type CarDto =
        {
        Id: Guid;
        Plate: string;
        Make: string;
        Model: string;
        }

    type UserDto =
        {
        Id: Guid;
        CognizantId: string;
        Name: string;
        Surname: string;
        Email: string;
        Car: CarDto [];
        }

    type IUserReadFacade =
        abstract member GetUserByCognizantId: CognizantId.T -> UserDto
        abstract member GetUsers: UserDto []    