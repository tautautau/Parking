namespace Parking.Domain.User

open System

open Parking.Infrastructure.FunctionChaining
open Parking.Infrastructure.WrappedString

module UserDomain = 
    

    module CarPlate = 
        type T = CarPlate of string with 
            interface IWrappedString with
                member this.Value = let (CarPlate s) = this in s

        let create = 
            //let canonicalize = //singleLineTrimmed 
            let validations =
                [|
                    ((fun (s: string) -> s.Length <> 6), "Car plate must be 6 symbols length")
                |]

            create singleLineTrimmed validations CarPlate

        let convert s = apply create s
    

    
    module Car =
        type T = 
            {
            Id: Guid;
            Plate: CarPlate.T;
            Make: String;
            Model: String;
            }

    module CognizantId = 
        type T = CognizantId of string with 
            interface IWrappedString with
                member this.Value = let (CognizantId s) = this in s

        let create = 
            //let canonicalize = //singleLineTrimmed 
            let validations =
                [|
                    ((fun (s: string) -> s.Length <> 6), "CognizantId must be 6 symbols length")
                |]

            create singleLineTrimmed validations CognizantId

        let convert s = apply create s


    type UserType =
    | ParkingPlaceOwner
    | TemporaryOwner
    | EmployeeWithoutParkingPlace

    type SpecialRights =
    | None
    | Admin
    | EET

    module User =
        type T =
            {
            Id:Guid;
            CognizantId: CognizantId.T;
            Name: string;
            Surname: string;
            Email: string;
            UserType: UserType;
            SpecialRights: SpecialRights;
            Car: Car.T [];
            }