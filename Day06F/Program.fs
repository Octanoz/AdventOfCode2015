open AdventUtilities
open AdventUtilities.Helpers.Grid
open LightGridFunctions

let inputData = InputData()
let input = inputData.ReadAllLines 6 "input" |> List.ofArray

let boolGrid = falseGrid 1000 1000
let lightGrid: int array2d = Array2D.zeroCreate 1000 1000

let part1 = input |> processPart1 boolGrid |> printfn "Part 1: %i"
let part2 = input |> processPart2 lightGrid |> printfn "Part 2: %i"
