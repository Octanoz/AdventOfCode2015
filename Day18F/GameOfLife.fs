module GameOfLife

open AdventUtilities.Helpers.Grid

//Part 1
let mapEvolution (grid: bool array2d) =
    [ for r in 0 .. (grid |> Array2D.length1) - 1 do
          for c in 0 .. (grid |> Array2D.length2) - 1 do
              let currentPosition = r, c

              let lights =
                  grid
                  |> checkEightNeighbours currentPosition
                  |> List.filter (fun (r, c) -> grid[r, c])
                  |> List.length

              yield currentPosition, lights ]
    |> Map.ofList

let updateGrid (map: Map<int * int, int>) (grid: bool array2d) =
    for r in 0 .. (grid |> Array2D.length1) - 1 do
        for c in 0 .. (grid |> Array2D.length2) - 1 do
            let pos = r, c

            match map[pos] with
            | 3 -> grid[r, c] <- true
            | 2 when grid |> valueAt pos = true -> grid[r, c] <- true
            | _ -> grid[r, c] <- false

let rec evolve grid steps =
    match steps with
    | 0 -> grid
    | n when steps > 0 ->
        let evolutionMap = grid |> mapEvolution
        grid |> updateGrid evolutionMap
        n - 1 |> evolve grid
    | _ -> failwithf "Invalid number of steps: %i" steps


//Part 2
let brokenGrid (grid: bool array2d) =
    grid[0, 0] <- true
    grid[0, 99] <- true
    grid[99, 0] <- true
    grid[99, 99] <- true

    grid

let updateGrid2 (map: Map<int * int, int>) (grid: bool array2d) =
    for r in 0 .. (grid |> Array2D.length1) - 1 do
        for c in 0 .. (grid |> Array2D.length2) - 1 do
            let pos = r, c

            if pos = (0, 0) || pos = (0, 99) || pos = (99, 0) || pos = (99, 99) then
                ()
            else
                match map[pos] with
                | 3 -> grid[r, c] <- true
                | 2 when grid |> valueAt pos = true -> grid[r, c] <- true
                | _ -> grid[r, c] <- false

let rec evolve2 grid steps =
    match steps with
    | 0 -> grid
    | n when steps > 0 ->
        let evolutionMap = grid |> mapEvolution
        grid |> updateGrid2 evolutionMap
        n - 1 |> evolve2 grid
    | _ -> failwithf "Invalid number of steps: %i" steps
