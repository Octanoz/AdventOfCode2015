open System.IO
open AdventUtilities
open AdventUtilities.Helpers.StringEx

let inputData = InputData()

let filePath = inputData.GetFilePath 2 "input"
let input = File.ReadAllLines filePath

let part1 =
    [ for line in input do
          let dims = getNums 'x' line

          match dims with
          | [ l; w; h ] ->
              let dimensions = [ l * w; w * h; h * l ]
              dimensions |> List.map ((*) 2) |> List.sum |> (+) (List.min dimensions)
          | _ -> 0 ]
    |> List.sum
    |> printfn "Part 1: %i"

let part2 =
    [ for line in input do
          let dims = getNums 'x' line |> List.sort

          match dims with
          | [ d1; d2; d3 ] ->
              let ribbonWrap = 2 * d1 + 2 * d2
              let ribbonBow = d1 * d2 * d3
              ribbonWrap + ribbonBow
          | _ -> 0 ]
    |> List.sum
    |> printfn "Part 2: %i"
