module Ingredients

open System
open AdventUtilities.Helpers.StringEx
open AdventUtilities.Helpers.MapExt

type Ingredient =
    { Name: String
      Capacity: Int32
      Durability: Int32
      Flavor: Int32
      Texture: Int32
      Calories: Int32 }

let rec mapIngredients input map =
    match input with
    | [] -> map
    | line :: rest ->
        let parts = line |> splitClean ' '

        match parts with
        | [ name; "capacity"; cap; "durability"; dur; "flavor"; flav; "texture"; txt; "calories"; cal ] ->
            let capLength, durLength, flavLength, textureLength, caloriesLength =
                cap.Length, dur.Length, flav.Length, txt.Length, cal.Length

            map
            |> updateMap
                name[.. name.Length - 2]
                { Name = name[.. name.Length - 2]
                  Capacity = int cap[.. capLength - 2]
                  Durability = int dur[.. durLength - 2]
                  Flavor = int flav[.. flavLength - 2]
                  Texture = int txt[.. textureLength - 2]
                  Calories = int cal }
            |> mapIngredients rest
        | _ -> failwithf "Unexpected line: %s" line

let getIngredients map = map |> Map.keys |> List.ofSeq

let rec distribute total parts =
    match parts with
    | 1 -> [ [ total ] ]
    | n ->
        [ for i in 0..total -> distribute (total - i) (n - 1) |> List.map (fun rest -> i :: rest) ]
        |> List.concat


let combos ingredients =
    ingredients
    |> List.length
    |> distribute (100 - (ingredients |> List.length))
    |> List.map (List.map ((+) 1))

let maxCombo4 (ingredientsList: string list) (map: Map<string, Ingredient>) =
    let allCombos = ingredientsList |> combos

    let score combo =
        let zipped = combo |> List.zip ingredientsList

        let propTotals =
            zipped
            |> List.fold
                (fun (cap, dur, flav, txt) (name, amount) ->
                    let ingredient = map[name]

                    cap + ingredient.Capacity * amount,
                    dur + ingredient.Durability * amount,
                    flav + ingredient.Flavor * amount,
                    txt + ingredient.Texture * amount)
                (0, 0, 0, 0)

        let capped =
            propTotals
            |> fun (cap, dur, flav, txt) -> [ cap; dur; flav; txt ] |> List.map (fun x -> max 0 x) |> List.reduce (*)

        capped

    allCombos |> List.map score |> List.max

let targetCalories = 500

let isTargetCalories (comboList: (string * int) list) (map: Map<string, Ingredient>) =
    comboList
    |> List.sumBy (fun (name, amount) -> map[name].Calories * amount)
    |> (=) targetCalories

let maxCombo500 (ingredientsList: string list) (map: Map<string, Ingredient>) =
    let allCombos = ingredientsList |> combos

    let score combo =
        let zipped = combo |> List.zip ingredientsList

        if map |> isTargetCalories zipped then

            let propTotals =
                zipped
                |> List.fold
                    (fun (cap, dur, flav, txt) (name, amount) ->
                        let ingredient = map[name]

                        cap + ingredient.Capacity * amount,
                        dur + ingredient.Durability * amount,
                        flav + ingredient.Flavor * amount,
                        txt + ingredient.Texture * amount)
                    (0, 0, 0, 0)

            let capped =
                propTotals
                |> fun (cap, dur, flav, txt) ->
                    [ cap; dur; flav; txt ] |> List.map (fun x -> max 0 x) |> List.reduce (*)

            Some capped
        else
            None

    allCombos |> List.choose score |> List.max
