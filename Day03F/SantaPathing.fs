module SantaPathing

open AdventUtilities.Helpers
open AdventUtilities.Helpers.ListExt

let start = 0, 0

//General movement function
let move (pos: int * int) (direction: char) =
    match direction with
    | '^' -> movePair pos (-1, 0)
    | '>' -> movePair pos (0, 1)
    | 'v' -> movePair pos (1, 0)
    | '<' -> movePair pos (0, -1)
    | _ -> pos

//Part 1 traversal rules
let rec traverse (instructions: string) (acc: (int * int) list) =
    match instructions.Length with
    | 0 -> acc |> List.distinct |> List.length
    | _ ->
        let currentPos = acc[0]
        let nextPos = instructions[0] |> move currentPos
        traverse instructions[1..] (acc |> addItem nextPos)

//Separate Santa and Robo-Santa instructions
let splitInstructions (s: string) =
    [ [ for i in 0..2 .. s.Length - 1 -> s[i] ]
      [ for i in 1..2 .. s.Length - 1 -> s[i] ] ]

//Part 2 traversal rules
let traverse2 instruction =
    instruction |> List.scan move start |> List.tail

let countCombined input =
    splitInstructions input
    |> List.map traverse2
    |> List.collect id
    |> List.distinct
    |> List.length
