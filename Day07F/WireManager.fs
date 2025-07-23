module WireManager

open AdventUtilities.TryParser
open AdventUtilities.Helpers.StringEx
open AdventUtilities.Helpers.MapExt
open AdventUtilities.Helpers.ListExt

let bitAnd a b = a &&& b
let bitOr a b = a ||| b
let bitNot a = ~~~a
let shiftLeft x shift = x <<< shift
let shiftRight x shift = x >>> shift

let rec processWires (unavailableWires: string list) (wires: string list) (wireMap: Map<string, int>) =
    match unavailableWires, wires with
    | [], [] -> wireMap["a"]
    | _, [] -> processWires [] unavailableWires wireMap
    | _, line :: tail ->
        let parts = line |> splitClean ' '

        let getValue s =
            match parseInt s with
            | Some v -> Some v
            | None -> wireMap |> Map.tryFind s

        let updateWire target value =
            processWires unavailableWires tail (wireMap |> updateMap target value)

        match parts with
        // NOT x -> y
        | [ "NOT"; src; "->"; target ] ->
            match getValue src with
            | Some v -> bitNot v |> updateWire target
            | None -> processWires (unavailableWires |> addItem line) tail wireMap

        // x AND y -> z
        | [ left; "AND"; right; "->"; target ] ->
            match getValue left, getValue right with
            | Some l, Some r -> bitAnd l r |> updateWire target
            | _ -> processWires (unavailableWires |> addItem line) tail wireMap

        // x OR y -> z
        | [ left; "OR"; right; "->"; target ] ->
            match getValue left, getValue right with
            | Some l, Some r -> bitOr l r |> updateWire target
            | _ -> processWires (unavailableWires |> addItem line) tail wireMap

        // x LSHIFT n -> y
        | [ src; "LSHIFT"; shift; "->"; target ] ->
            match getValue src, parseInt shift with
            | Some v, Some s -> shiftLeft v s |> updateWire target
            | _ -> processWires (unavailableWires |> addItem line) tail wireMap

        // x RSHIFT n -> y
        | [ src; "RSHIFT"; shift; "->"; target ] ->
            match getValue src, parseInt shift with
            | Some v, Some s -> shiftRight v s |> updateWire target
            | _ -> processWires (unavailableWires |> addItem line) tail wireMap

        // n -> x or wire -> x
        | [ src; "->"; target ] ->
            match getValue src with
            | Some v -> updateWire target v
            | None -> processWires (unavailableWires |> addItem line) tail wireMap

        // should never reach
        | _ -> failwithf "Unexpected line: %s" line
