module Traveller

open AdventUtilities.Helpers.StringEx
open AdventUtilities.Helpers.ListExt

let rec distanceMap (travelLines: string list) (map: Map<string * string, int>) =
    match travelLines with
    | [] -> map
    | line :: tail ->
        match line |> splitClean ' ' with
        | [ origin; "to"; destination; "="; distance ] ->
            let dist = int distance

            map
            |> Map.add (origin, destination) dist
            |> Map.add (destination, origin) dist
            |> distanceMap tail
        | _ -> failwithf "Unexpected line: %s" line


let getCities (map: Map<string * string, int>) =
    map
    |> Map.keys
    |> Seq.collect (fun (a, b) -> [ a; b ])
    |> Seq.distinct
    |> List.ofSeq

let populateGrid (cities: string list) (map: Map<string * string, int>) =
    let dimension = cities.Length
    let grid = Array2D.zeroCreate dimension dimension

    for row in 0 .. dimension - 1 do
        for col in 0 .. dimension - 1 do
            if row = col then
                grid[row, col] <- 0
            else
                grid[row, col] <- map[cities[row], cities[col]]

    grid

let drawGrid (grid: int array2d) =
    for row in 0 .. (grid |> Array2D.length1) - 1 do
        for col in 0 .. (grid |> Array2D.length2) - 1 do
            printf "%i " grid[row, col]

        printfn ""

let rec permutations list =
    match list with
    | [] -> [ [] ]
    | _ ->
        [ for i in 0 .. list.Length - 1 do
              let rest = mergeLists list[.. i - 1] list[i + 1 ..]

              for permute in permutations rest do
                  addItem list[i] permute ]

let routeDistance (grid: int array2d) (path: int list) =
    path |> List.pairwise |> List.sumBy (fun (a, b) -> grid[a, b])
