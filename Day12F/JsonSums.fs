module JsonSums

open System.Text.Json

let json (input: string) = JsonDocument.Parse(input).RootElement

let rec sumNumbers (element: JsonElement) =
    match element.ValueKind with
    | JsonValueKind.Object -> element.EnumerateObject() |> Seq.sumBy (fun prop -> sumNumbers prop.Value)
    | JsonValueKind.Array -> element.EnumerateArray() |> Seq.sumBy sumNumbers
    | JsonValueKind.Number -> element.GetInt32()
    | _ -> 0

let hasRedValue (element: JsonElement) : bool =
    match element.ValueKind with
    | JsonValueKind.Object ->
        element.EnumerateObject()
        |> Seq.exists (fun prop -> prop.Value.ValueKind = JsonValueKind.String && prop.Value.GetString() = "red")
    | _ -> false

let rec sumIgnoreRed (element: JsonElement) =
    match element.ValueKind with
    | JsonValueKind.Object ->
        if hasRedValue element then
            0
        else
            element.EnumerateObject() |> Seq.sumBy (fun prop -> sumIgnoreRed prop.Value)
    | JsonValueKind.Array -> element.EnumerateArray() |> Seq.sumBy sumIgnoreRed
    | JsonValueKind.Number -> element.GetInt32()
    | _ -> 0
