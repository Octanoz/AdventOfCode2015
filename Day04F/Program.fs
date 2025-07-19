open System
open System.IO
open System.Text
open System.Security.Cryptography
open AdventUtilities

let inputData = InputData()
let filePath = inputData.GetFilePath 4 "example1"
let example = File.ReadAllLines filePath

let input = "bgvyzdsv"

let findFiveZeroes (prefix: string) =
    let rec searchFive i =
        let candidate = prefix + string i
        let bytes = Encoding.UTF8.GetBytes candidate
        let hash = MD5.HashData bytes |> Convert.ToHexString
        if hash.StartsWith "00000" then i else searchFive (i + 1)

    searchFive 0

let findSixZeroes (prefix: string) =
    let rec searchSix i =
        let candidate = prefix + string i
        let bytes = Encoding.UTF8.GetBytes candidate
        let hash = MD5.HashData bytes |> Convert.ToHexString
        if hash.StartsWith "000000" then i else searchSix (i + 1)

    searchSix 0

for line in example do
    let result = findFiveZeroes line
    printfn "Result for %s: %i" line result

let part1 = input |> findFiveZeroes
printfn "Part 1: %i" part1

let part2 = input |> findSixZeroes
printfn "Part 2: %i" part2
