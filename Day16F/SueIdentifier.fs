module SueIdentifier

open System
open AdventUtilities.Helpers.ListExt

let giftingSue =
    Map
        [ "akitas", -1
          "cars", 2
          "cats", 7
          "children", 3
          "goldfish", 5
          "perfumes", 1
          "pomeranians", 3
          "samoyeds", 2
          "trees", 3
          "vizslas", -1 ]

let rec findSue1 (input: string list) =
    match input with
    | [] -> 0
    | current :: rest ->
        let colonIndex = current.IndexOf ':'
        let number = int current[4 .. colonIndex - 1]

        let properties =
            current[colonIndex + 2 ..]
                .Split([| ": "; ", " |], StringSplitOptions.RemoveEmptyEntries)
            |> Array.pairwise
            |> Array.filter (fun (_, n) -> Char.IsDigit n[0])
            |> Array.map (fun (prop, num) -> prop, int num)
            |> Array.sort
            |> Map.ofArray

        let keys = properties |> Map.keys |> List.ofSeq

        let rec filterSue1 (propertyMap: Map<string, int>) (keys: string list) =
            match keys with
            | [] -> number
            | prop :: others ->
                match giftingSue[prop] with
                | num when propertyMap[prop] = num -> others |> filterSue1 propertyMap
                | _ -> rest |> findSue1

        keys |> filterSue1 properties

let rec findSue2 (input: string list) (numberList: int list) =
    match input with
    | [] -> numberList
    | current :: rest ->
        let colonIndex = current.IndexOf ':'
        let number = int current[4 .. colonIndex - 1]

        let properties =
            current[colonIndex + 2 ..]
                .Split([| ": "; ", " |], StringSplitOptions.RemoveEmptyEntries)
            |> Array.pairwise
            |> Array.filter (fun (_, n) -> Char.IsDigit n[0])
            |> Array.map (fun (prop, num) -> prop, int num)
            |> Array.sort
            |> Map.ofArray

        let keys = properties |> Map.keys |> List.ofSeq

        let rec filterSue2 (propertyMap: Map<string, int>) (keys: string list) =
            match keys with
            | [] -> numberList |> addItem number |> findSue2 rest
            | prop :: others ->
                match prop with
                | "cats" when propertyMap["cats"] > giftingSue["cats"] -> 
                    others |> filterSue2 propertyMap
                | "trees" when propertyMap["trees"] > giftingSue["trees"] ->
                    others |> filterSue2 propertyMap
                | "pomeranians" when propertyMap["pomeranians"] < giftingSue["pomeranians"] ->
                    others |> filterSue2 propertyMap
                | "goldfish" when propertyMap["goldfish"] < giftingSue["goldfish"] ->
                    others |> filterSue2 propertyMap
                | _ when propertyMap[prop] = giftingSue[prop] ->
                    others |> filterSue2 propertyMap
                | _ -> numberList |> findSue2 rest

        keys |> filterSue2 properties
