open AdventUtilities
open AdventUtilities.Maths
open AdventUtilities.Helpers.ListExt
open GuestManager

let inputData = InputData()
let example = inputData.ReadAllLines 13 "example1" |> List.ofArray
let input = inputData.ReadAllLines 13 "input" |> List.ofArray

let guestMap = input |> happyMap Map.empty
let guestsList = guestMap |> getGuests
let guestsAndMeList = guestsList |> addItem "Me"

let part1 =
    guestsList
    |> permutations
    |> List.map (fun arrangement -> guestMap |> happinessCount arrangement)
    |> List.max
    |> printfn "Part 1: %i"

let mapWithMe = guestMap |> addMeToMap guestsList

let part2 =
    guestsAndMeList
    |> permutations
    |> List.map (fun arrangement -> mapWithMe |> happinessCount arrangement)
    |> List.max
    |> printfn "Part 2: %i"
