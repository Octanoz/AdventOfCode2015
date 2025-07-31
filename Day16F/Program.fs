open System
open AdventUtilities
open SueIdentifier

let inputData = InputData()
let input = inputData.ReadAllLines 16 "input" |> List.ofArray

let part1 = input |> findSue1 |> printfn "Part 1: %i"
let part2 = [] |> findSue2 input |> List.head |> printfn "Part 2: %A"
