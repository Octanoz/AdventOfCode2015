module PasswordGenerator

open System

let toIntArray (alphabet: string) (input: string) =
    input |> Seq.map (fun c -> alphabet.IndexOf c) |> Array.ofSeq

//Index 0 will never wrap around so no need for a special case for it
let carryOverArray (arr: int array) =
    for i = arr.Length - 1 downto 0 do
        if arr[i] = 23 then
            arr[i] <- 0
            arr[i - 1] <- arr[i - 1] + 1

//Regex (\w)\1.*(\w)\2 works but this approach is faster
let hasTwoPair arr =
    arr
    |> Array.windowed 2
    |> Array.choose (function
        | [| a; b |] when a = b -> Some a
        | _ -> None)
    |> Array.distinct
    |> Array.length
    >= 2

let isValid passwordArray =
    let hasTriple =
        passwordArray
        |> Array.windowed 3
        //Forbidden letters 'i, l, o' are so close together they can be avoided by skipping a whole range of first letter values when checking for the increasing three letters
        //With the adjusted alphabet you only have to skip 6 through 11 as the first digit
        |> Array.exists (fun [| a; b; c |] -> (a < 6 || a > 11) && a + 1 = b && b + 1 = c)

    hasTriple && passwordArray |> hasTwoPair

//Start with incrementing the last letter so you don't approve the original input, check for carry over, validate with the rules, rinse repeat, uhh... recursion
let rec findValidPassword (alphabet: string) (passwordArray: int array) : string =
    passwordArray[7] <- passwordArray[7] + 1
    passwordArray |> carryOverArray

    //If sequence is valid return the array as a string using the adjusted alphabet, otherwise recursively increment the last digit
    if passwordArray |> isValid then
        passwordArray |> Array.map (fun n -> alphabet[n]) |> String
    else
        passwordArray |> findValidPassword alphabet
