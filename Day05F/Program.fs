open System.IO
open System.Text.RegularExpressions
open AdventUtilities

let inputData = InputData()
let filePath = inputData.GetFilePath 5 "input"
let input = File.ReadAllLines filePath |> List.ofArray

let vowels = [ 'a'; 'e'; 'i'; 'o'; 'u' ]
let forbidden = [ "ab"; "cd"; "pq"; "xy" ]

let isNice (line: string) =
    let hasVowel =
        line |> Seq.filter (fun c -> vowels |> List.contains c) |> Seq.length >= 3

    let hasDouble = line |> Seq.pairwise |> Seq.exists (fun (a, b) -> a = b)
    let hasForbidden = forbidden |> List.exists line.Contains

    hasVowel && hasDouble && not hasForbidden

let isNice2 (line: string) =
    let repeatingPair = new Regex @"(\w{2}).*\1"
    let repeatingLetter = new Regex @"(\w).\1"

    repeatingLetter.IsMatch line && repeatingPair.IsMatch line

let countNiceStrings lines =
    lines |> List.filter isNice |> List.length

let countNiceStrings2 lines =
    lines |> List.filter isNice2 |> List.length

printfn "Part 1: %i" (countNiceStrings input)
printfn "Part 2: %i" (countNiceStrings2 input)
