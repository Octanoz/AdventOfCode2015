open AdventUtilities

let inputData = InputData()
let input = inputData.ReadAllText 1 "input"

//Part 1
input
|> Seq.sumBy (fun c -> if c = '(' then 1 else -1)
|> printfn "Part 1: Floor %i"

//Part 2
input
|> Seq.scan (fun acc c -> acc + if c = '(' then 1 else -1) 0
|> Seq.findIndex ((=) -1)
|> printfn "Part 2: First basement instruction at position %i"
