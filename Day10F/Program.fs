open System.Text

let example = "1"
let input = "1113222113"

let hearSay input times =
    let rec compress (line: string) (index: int) (currentLetter: char) (count: int) (sb: StringBuilder) =
        if index >= line.Length then
            sb.Append(count).Append(currentLetter) |> ignore
        else
            let c = line[index]

            if c = currentLetter then
                compress line (index + 1) currentLetter (count + 1) sb
            else
                sb.Append(count).Append(currentLetter) |> ignore
                compress line (index + 1) c 1 sb

    let rec iterate line n =
        match n = 0 with
        | true -> line
        | _ ->
            let sb = StringBuilder()
            compress line 1 line[0] 1 sb
            iterate (sb |> string) (n - 1)

    iterate input times

let test = hearSay example 5 |> printfn "Example: %s"

let part1 = hearSay input 40 |> String.length |> printfn "Part 1: %i"
let part2 = hearSay input 50 |> String.length |> printfn "Part 2: %i"
