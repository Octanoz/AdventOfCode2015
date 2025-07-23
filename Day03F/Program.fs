open AdventUtilities
open SantaPathing

let inputData = InputData()
let input = inputData.ReadAllText 3 "input"

let part1 = [ 0, 0 ] |> traverse input |> printfn "Part 1: %i"
let part2 = input |> countCombined |> printfn "Part2: %i"
