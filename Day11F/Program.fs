open PasswordGenerator

//Don't include forbidden letters in alphabet or initial input
let alphabet = "abcdefghjkmnpqrstuvwxyz"
let example = "abcdefgh"
let input = "cqjxjnds"

//Convert strings to int arrays for easier maths and allowing in place changes, only convert back to string when a valid sequence is found
let exampleArray = example |> toIntArray alphabet

let exampleResult =
    exampleArray |> findValidPassword alphabet |> printfn "Example: %s"

let inputArray = input |> toIntArray alphabet

//As part 2 asks for the next valid password after the part 1 result we can just continue with the same array since it will already be at that stage
let part1 = inputArray |> findValidPassword alphabet |> printfn "Part 1: %s"
let part2 = inputArray |> findValidPassword alphabet |> printfn "Part 2: %s"
