namespace Parking.Domain.Admin

open Parking.Infrastructure.FunctionChaining

module AdminDomain = 
    
    module CarPlate =
        type T = CarPlate of string
        let isValid(s: string) =
            match s with
            | null -> Failure
            | str when str.Length > 6 -> Failure
            | _ -> Success

        // let create (s: string) =
        //     isValid >> (CarPlate s)
        
        // let apply f (CarPlate s) = f s
        // let value s = apply id s

    //type PlateNumber of int * int * int * char * char * char
    
    //type Car() =
