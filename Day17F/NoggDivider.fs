module NoggDivider

open AdventUtilities.Maths

let rec countCombos (containers: int list) (target: int) =
    match containers, target with
    | _, t when t < 0 -> 0
    | [], 0 -> 1
    | [], _ -> 0
    | head :: tail, target -> countCombos tail (target - head) + countCombos tail target

let countCombosWithLength containers target length =
    combinations containers length
    |> List.filter (fun combo -> List.sum combo = target)
    |> List.length

let shortestCombo (containers: int list) (target: int) =
    let validLengths =
        [ 1 .. (containers |> List.length) / 2 ]
        |> List.map (fun len -> len, countCombosWithLength containers target len)
        |> List.filter (fun (_, count) -> count > 0)

    match validLengths with
    | [] -> 0
    | _ ->
        let minlength, _ = validLengths |> List.minBy fst

        minlength
