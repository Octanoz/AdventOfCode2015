open AdventUtilities
open ReindeerTracker

let inputData = InputData()
let example = inputData.ReadAllLines 14 "example1" |> List.ofArray
let input = inputData.ReadAllLines 14 "input" |> List.ofArray

let time = 2503

let reindeerMap = Map.empty |> deerMap input

let part1 = furthestDeer time (listOfDeer reindeerMap) reindeerMap
printfn "Part 1: %i" part1

let part2 = winningScore time reindeerMap
printfn "Part 2: %i" part2
