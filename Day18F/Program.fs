open AdventUtilities
open AdventUtilities.Helpers.Grid
open GameOfLife

let inputData = InputData()
let example = inputData.ReadAllLines 18 "example1"
let input = inputData.ReadAllLines 18 "input"

let exampleGrid = example |> stringArrayTo2DCharArray |> charGridToBoolGrid

let exampleOutput =
    4 |> evolve exampleGrid |> countTrue |> printfn "Example: %i lights\n"

let challengeGrid = input |> stringArrayTo2DCharArray |> charGridToBoolGrid

let part1 = 100 |> evolve challengeGrid |> countTrue |> printfn "Part 1: %i lights"

let secondChallengeGrid =
    input |> stringArrayTo2DCharArray |> charGridToBoolGrid |> brokenGrid

let part2 =
    100 |> evolve2 secondChallengeGrid |> countTrue |> printfn "Part 2: %i lights"
