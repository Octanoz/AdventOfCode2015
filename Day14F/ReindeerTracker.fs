module ReindeerTracker

open AdventUtilities.Helpers.StringEx

let rec deerMap (lines: string list) (map: Map<string, (int * int * int)>) =
    match lines with
    | [] -> map
    | head :: tail ->
        let parts = head |> splitClean ' '

        match parts with
        | [ deer; _; _; speed; _; _; sprintTime; _; _; _; _; _; _; restTime; _ ] ->
            map |> Map.add deer (int speed, int sprintTime, int restTime) |> deerMap tail
        | _ -> failwithf "Unexpected line: %s" head

let listOfDeer (map: Map<string, (int * int * int)>) = map |> Map.keys |> List.ofSeq

let furthestDeer (time: int) (deerList: string list) (map: Map<string, (int * int * int)>) =
    let rec traverse (dList: string list) (acc: int list) =
        match dList with
        | [] -> acc |> List.max
        | head :: tail ->
            let spd, sprint, rest = map[head]
            let cycles = time / (sprint + rest)
            let remaining = time % (sprint + rest)
            let distance = spd * (cycles * sprint + min sprint remaining)
            traverse tail (distance :: acc)

    traverse deerList []

type ReindeerState =
    { speed: int
      sprintTime: int
      restTime: int
      distance: int
      points: int
      isSprinting: bool
      timeInMode: int }

let winningScore (time: int) (map: Map<string, (int * int * int)>) =
    let deerNames = map |> Map.keys |> List.ofSeq

    let initialState =
        deerNames
        |> List.map (fun name ->
            let spd, sprint, rest = map[name]

            let state =
                { speed = spd
                  sprintTime = sprint
                  restTime = rest
                  distance = 0
                  points = 0
                  isSprinting = true
                  timeInMode = 0 }

            name, state)
        |> Map.ofList

    let rec race (t: int) (states: Map<string, ReindeerState>) =
        if t > time then
            states
        else
            let updatedStates =
                states
                |> Map.map (fun _ state ->
                    let newDistance =
                        if state.isSprinting then
                            state.distance + state.speed
                        else
                            state.distance

                    let newTimeInMode = state.timeInMode + 1

                    let newIsSprinting, finalTimeInMode =
                        if state.isSprinting && newTimeInMode = state.sprintTime then
                            false, 0
                        elif not state.isSprinting && newTimeInMode = state.restTime then
                            true, 0
                        else
                            state.isSprinting, newTimeInMode

                    { state with
                        distance = newDistance
                        isSprinting = newIsSprinting
                        timeInMode = finalTimeInMode })

            let maxDistance =
                updatedStates |> Map.values |> Seq.map (fun s -> s.distance) |> Seq.max

            let leaders =
                updatedStates |> Map.filter (fun _ state -> state.distance = maxDistance)

            let statesWithPoints =
                updatedStates
                |> Map.map (fun name state ->
                    if leaders |> Map.containsKey name then
                        { state with points = state.points + 1 }
                    else
                        state)

            race (t + 1) statesWithPoints

    let finalStates = race 1 initialState
    finalStates |> Map.values |> Seq.map (fun s -> s.points) |> Seq.max
