open System
open AdventUtilities
open NoggDivider

let inputData = InputData()

let example =
    inputData.ReadAllLines 17 "example1" |> Array.map int32 |> List.ofArray

let input =
    inputData.ReadAllLines 17 "input"
    |> Array.map int32
    |> Array.sort
    |> List.ofArray

let exampleOutput = countCombos example 25 |> printfn "Example combos: %i\n"

let part1 = countCombos input 150 |> printfn "Part 1: %i combos"
let part2 = shortestCombo input 150 |> printfn "Part 2: %i containers"
