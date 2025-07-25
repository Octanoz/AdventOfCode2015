namespace AdventUtilities

open AdventUtilities.Helpers.ListExt

module Maths =

    let rec permutations elements =
        match elements with
        | [] -> [ [] ]
        | elem :: tail ->
            permutations tail
            |> List.collect (fun perm -> [ for i in 0 .. perm.Length -> perm[.. i - 1] @ [ elem ] @ perm[i..] ])

    let rec combinations elements n =
        match n, elements with
        | 0, _ -> [ [] ]
        | _, [] -> []
        | n, head :: tail ->
            let withHead =
                combinations tail (n - 1) |> List.map (fun combo -> combo |> addItem head)

            let withoutHead = combinations tail n

            mergeLists withHead withoutHead

    let rec gcd a b = if b = 0L then a else gcd b (a % b)

    let lcm a b = a * b / gcd a b

    let rec factorial n =
        if n <= 1 then 1L else int64 n * factorial (n - 1)

    let isPrime n =
        match n with
        | _ when n < 2L -> false
        | 2L -> true
        | _ when n % 2L = 0L -> false
        | _ ->
            let squareRoot = int64 (sqrt (float n))
            seq { 3L .. 2L .. squareRoot } |> Seq.forall (fun i -> n % i <> 0L)

    let sieveOfEratosthenes n =
        let primeArray = Array.create (n + 1) true

        if n >= 0 then
            primeArray[0] <- false

        if n >= 1 then
            primeArray[1] <- false

        for i in 2 .. int (sqrt (float n)) do
            if primeArray[i] then
                for j in i * i .. i .. n do
                    primeArray[j] <- false

        [ for i in 0..n do
              if primeArray[i] then
                  yield i ]
