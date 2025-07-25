module GuestManager

open AdventUtilities.Helpers.StringEx
open AdventUtilities.Helpers.MapExt

let rec happyMap (map: Map<string * string, int>) (lines: string list) =
    match lines with
    | [] -> map
    | line :: tail ->
        let parts = line |> splitClean ' '

        match parts with
        | [ guest; _; "gain"; number; _; _; _; _; _; _; neighbour ] ->
            happyMap (map |> updateMap (guest, neighbour[.. neighbour.Length - 2]) (int number)) tail
        | [ guest; _; "lose"; number; _; _; _; _; _; _; neighbour ] ->
            happyMap (map |> updateMap (guest, neighbour[.. neighbour.Length - 2]) -(int number)) tail
        | _ -> failwithf "Unexpected line: %s" line

let rec addMeToMap (guests: string list) (map: Map<string * string, int>) =
    match guests with
    | [] -> map
    | guest :: rest -> map |> updateMap ("Me", guest) 0 |> updateMap (guest, "Me") 0 |> addMeToMap rest

let getGuests (map: Map<string * string, int>) =
    map
    |> Map.keys
    |> Seq.collect (fun (a, b) -> [ a; b ])
    |> Seq.distinct
    |> List.ofSeq

let happinessCount (guests: string list) (guestMap: Map<string * string, int>) =
    let totalGuests = guests.Length

    [ for i in 0 .. totalGuests - 1 ->
          guestMap[guests[i], guests[(i + totalGuests - 1) % totalGuests]]
          + guestMap[guests[i], guests[(i + 1) % totalGuests]] ]
    |> List.sum
