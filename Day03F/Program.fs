open System.IO
open AdventUtilities

let inputData = InputData()
let filePath = inputData.GetFilePath 3 "input"

let input = File.ReadAllText filePath

let start = 0, 0

let rec traverse (instructions: string) (acc: (int * int) list) =
    match instructions.Length with
    | 0 -> acc |> List.distinct |> List.length
    | _ ->
        let currentPos = List.head acc

        let nextPos =
            match instructions[0] with
            | '^' -> fst currentPos - 1, snd currentPos
            | '>' -> fst currentPos, snd currentPos + 1
            | 'v' -> fst currentPos + 1, snd currentPos
            | '<' -> fst currentPos, snd currentPos - 1
            | _ -> currentPos

        traverse instructions[1..] (nextPos :: acc)

let result = traverse input [ start ]

printfn "Part 1: %i" result

let move (pos: int * int) (direction: char) =
    match direction with
    | '^' -> fst pos |> (+) -1, snd pos
    | '>' -> fst pos, snd pos |> (+) 1
    | 'v' -> fst pos |> (+) 1, snd pos
    | '<' -> fst pos, snd pos |> (+) -1
    | _ -> pos

let splitInstructions (s: string) =
    [ [ for i in 0..2 .. s.Length - 1 -> s[i] ]
      [ for i in 1..2 .. s.Length - 1 -> s[i] ] ]

let traverse2 instruction =
    instruction |> List.scan move start |> List.tail

let result2 =
    splitInstructions input
    |> List.map traverse2
    |> List.collect id
    |> List.distinct
    |> List.length

printfn "Part 2: %i" result2
