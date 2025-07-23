module LightGridFunctions

open AdventUtilities.Helpers.StringEx
open AdventUtilities.Helpers.Grid

let turnTrue (grid: bool array2d) startRow startCol endRow endCol =
    for r in startRow..endRow do
        for c in startCol..endCol do
            grid[r, c] <- true

    grid

let turnFalse (grid: bool array2d) startRow startCol endRow endCol =
    for r in startRow..endRow do
        for c in startCol..endCol do
            grid[r, c] <- false

    grid

let toggleBool (grid: bool array2d) startRow startCol endRow endCol =
    for r in startRow..endRow do
        for c in startCol..endCol do
            grid[r, c] <- not grid[r, c]

    grid

let turnOn (grid: int array2d) startRow startCol endRow endCol =
    for r in startRow..endRow do
        for c in startCol..endCol do
            grid[r, c] <- grid[r, c] + 1

    grid

let turnOff (grid: int array2d) startRow startCol endRow endCol =
    for r in startRow..endRow do
        for c in startCol..endCol do
            grid[r, c] <- max 0 (grid[r, c] - 1)

    grid

let toggleLight (grid: int array2d) startRow startCol endRow endCol =
    for r in startRow..endRow do
        for c in startCol..endCol do
            grid[r, c] <- grid[r, c] + 2

    grid

let parseCoordinates start finish =
    let startLocation = start |> getNums ','
    let endLocation = finish |> getNums ','
    startLocation[0], startLocation[1], endLocation[0], endLocation[1]

let processBoolLine (grid: bool array2d) (line: string) =
    let parts = line.Split ' '

    match parts[0], parts[1] with
    | "toggle", _ ->
        let startRow, startCol, endRow, endCol = parseCoordinates parts[1] parts[3]
        toggleBool grid startRow startCol endRow endCol
    | "turn", "on" ->
        let startRow, startCol, endRow, endCol = parseCoordinates parts[2] parts[4]
        turnTrue grid startRow startCol endRow endCol
    | _ ->
        let startRow, startCol, endRow, endCol = parseCoordinates parts[2] parts[4]
        turnFalse grid startRow startCol endRow endCol

let processPart1 grid lines =
    lines |> List.fold processBoolLine grid |> countTrue

let processLightLine (grid: int array2d) (line: string) =
    let parts = line.Split ' '

    match parts[0], parts[1] with
    | "toggle", _ ->
        let startRow, startCol, endRow, endCol = parseCoordinates parts[1] parts[3]
        toggleLight grid startRow startCol endRow endCol
    | "turn", "on" ->
        let startRow, startCol, endRow, endCol = parseCoordinates parts[2] parts[4]
        turnOn grid startRow startCol endRow endCol
    | _ ->
        let startRow, startCol, endRow, endCol = parseCoordinates parts[2] parts[4]
        turnOff grid startRow startCol endRow endCol

let processPart2 grid lines =
    lines |> List.fold processLightLine grid |> countTotal
