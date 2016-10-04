namespace Parking.Domain.User

open Parking.Infrastructure.FunctionChaining
open System

module UserDomain = 
    
    module CarPlate =
        type T = CarPlate of string
        let isValid (s: string) =
            match s with
            | null -> Failure "Car plate can't not be null"
            | str when str.Length > 6 -> Failure "Car plate can't be longer than 6 symbols"
            | _ -> Success s

        let create (s: string) =
             isValid s |> map (CarPlate)
    
        let apply f (CarPlate s) = f s
        let value s = apply id s
    

    
    module Car =
        type T = 
            {
            Ids: Guid;
            CarPlate: CarPlate.T;
            Make: String;
            Model: String;
            }
        
    let niceJob = ((fun (s: string) -> s.Length < 6), "Car plate can't be longer than 6 symbols")

    let z = (fun d -> (printfn "%s" (snd niceJob))) 
    

    // let array1 =
    //     [|
    //         ((fun (s: string) -> s.Length > 6), "Car plate can't be longer than 6 symbols")
    //         ((fun (s: string) -> s.Length <> 6), "Car plate must be 6 symbols length")
    //     |]

    // array1
    // |> Array.filter (fun elem -> (fst elem) "abcd2")
    // |> Array.forall (fun d -> (printfn "%s" (snd d))) 