//Basis taken from: https://fsharpforfunandprofit.com/posts/designing-with-types-more-semantic-types/
namespace Parking.Infrastructure

open Parking.Infrastructure.FunctionChaining

open System

module WrappedString = 
    /// An interface that all wrapped strings support
    type IWrappedString = 
        abstract Value : string

    let singleLineTrimmed s =
        System.Text.RegularExpressions.Regex.Replace(s,"\s"," ").Trim()

    let joinFailureMessages (validationFailures: ((string -> bool) * string)[]) =
        validationFailures
        |> Array.map (fun x -> (snd x))
        |> String.concat @"\n"

    let processValueCanonized canonicalize validations ctor (s:string) =
        let s' = canonicalize s

        let validationFailures = 
            validations
            |> Array.filter (fun elem -> (fst elem) s')
            |> Array.map (fun x -> (snd x))
            |> String.concat @"\n"

        match validationFailures.ToCharArray() with
        | [||] -> Success (ctor s')
        | _ -> Failure validationFailures

    let create canonicalize validations ctor (s:string) = 
        match s with
        | null -> Failure (ctor.ToString()+"is null")
        | _ ->  processValueCanonized canonicalize validations ctor (s:string)        

    /// Apply the given function to the wrapped value
    let apply f (s:IWrappedString) = 
        s.Value |> f 

    /// Get the wrapped value
    let value s = apply id s

    /// Equality test
    let equals left right = 
        (value left) = (value right)
        
    /// Comparison
    let compareTo left right = 
        (value left).CompareTo (value right)