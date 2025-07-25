open AdventUtilities
open AdventUtilities.Maths
open Traveller

let inputData = InputData()
let input = inputData.ReadAllLines 9 "input" |> List.ofArray

let travelMap = Map.empty |> distanceMap input
let cities = travelMap |> getCities
let populatedGrid = populateGrid cities travelMap

populatedGrid |> drawGrid

let indices = [ 0 .. (cities.Length - 1) ]

let part1 =
    indices
    |> permutations
    |> List.map (routeDistance populatedGrid)
    |> List.min
    |> printfn "Part 1: %i"

let part2 =
    indices
    |> permutations
    |> List.map (routeDistance populatedGrid)
    |> List.max
    |> printfn "Part 2: %i"
