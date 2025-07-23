open AdventUtilities
open WireManager

let inputData = InputData()
let input = inputData.ReadAllLines 7 "input" |> List.ofArray

let part1 = processWires [] input Map.empty |> printfn "Part 1: %i"

let part2 =
    processWires [] (input |> List.filter (fun line -> line.EndsWith "-> b" |> not)) (Map [ ("b", 956) ])
    |> printfn "Part 2: %i"
