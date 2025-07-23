open AdventUtilities

let inputData = InputData()
let input = inputData.ReadAllLines 8 "input"

let rec memoryCount (index: int) (count: int) (line: string) =
    if index >= line.Length - 1 then
        count
    else
        match line[index], line[index + 1] with
        | '\\', '\\'
        | '\\', '"' -> line |> memoryCount (index + 2) (count + 1)
        | '\\', 'x' when index + 3 < line.Length -> line |> memoryCount (index + 4) (count + 1)
        | _ -> line |> memoryCount (index + 1) (count + 1)

let rec encodedCount (count: int) (line: string) =
    match line.Length with
    | 0 -> count + 2
    | _ ->
        match line[0] with
        | '\\' -> encodedCount (count + 2) line[1..]
        | '"' -> encodedCount (count + 2) line[1..]
        | _ -> encodedCount (count + 1) line[1..]


let part1 =
    input
    |> Array.sumBy (fun line -> line.Length - (line |> memoryCount 1 0))
    |> printfn "Part 1: %i"

let part2 =
    input
    |> Array.sumBy (fun line -> (line |> encodedCount 0) - line.Length)
    |> printfn "Part 2: %i"
