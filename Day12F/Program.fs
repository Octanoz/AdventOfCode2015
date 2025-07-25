open System.IO
open AdventUtilities
open JsonSums

let inputData = InputData()
let filePath = inputData.GetNonTextFilePath 12 "input.json"

let input = File.ReadAllText filePath

let jsonRoot = json input

let part1 = jsonRoot |> sumNumbers |> printfn "Part 1: %i"
let part2 = jsonRoot |> sumIgnoreRed |> printfn "Part 2: %i"
