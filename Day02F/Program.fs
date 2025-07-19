open System.IO
open AdventUtilities

let inputData = InputData()

let filePath = inputData.GetFilePath 2 "input"
let input = File.ReadAllLines filePath

let part1 =
    [ for line in input do
          let dims = line.Split 'x' |> Array.map int

          match dims with
          | [| l; w; h |] ->
              let dimensions = [ l * w; w * h; h * l ]

              dimensions |> List.map ((*) 2) |> List.sum |> (+) (List.min dimensions) ]
    |> List.sum
    |> printfn "Part 1: %i"

let part2 =
    [ for line in input do
          let dims = line.Split 'x' |> Array.map int |> Array.sort

          match dims with
          | [| d1; d2; d3 |] ->
              let ribbonWrap = (2 * d1) + (2 * d2)
              let ribbonBow = d1 * d2 * d3
              ribbonWrap + ribbonBow
          | _ -> 0 ]
    |> List.sum
    |> printfn "Part 2: %i"
