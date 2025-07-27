open AdventUtilities
open Ingredients

let inputData = InputData()
let example = inputData.ReadAllLines 15 "example1" |> List.ofArray
let input = inputData.ReadAllLines 15 "input" |> List.ofArray

let exampleIngredientsMap = Map.empty |> mapIngredients example
let exampleIngredientsList = exampleIngredientsMap |> getIngredients

let exampleOutput =
    exampleIngredientsMap
    |> maxCombo4 exampleIngredientsList
    |> printfn "Example: %d"

printfn ""

let ingredientsMap = Map.empty |> mapIngredients input
let ingredientsList = ingredientsMap |> getIngredients

let part1 = ingredientsMap |> maxCombo4 ingredientsList |> printfn "Part 1: %d"
let part2 = ingredientsMap |> maxCombo500 ingredientsList |> printfn "Part 2: %d"
