# **Solutions for Advent of  2015 in C# and F#**

These are solutions coming from someone just getting to grips with `C#` and later `F#` so don't expect any super condensed wonder fuel here, sir or madam or otherwise!

<details><summary>TL;DR</summary>
I got into coding late 2023, I'd say. Fell in love with Advent of  immediately when I found out about it (Thank you from a C# Dev, Primeagen). Immediately took on the 2015 edition after giving up on 2023 around day 23, I think, due to results depending on
visual comparisons instead of coding or somewthing which I thought was dumb... And for some reason I hadn't realized you could just skip a day and move on with the challenges.

Anywho... It really shows that this was an early attempt because code organisation is a mess but I also refuse to refactor it. It's a testament if you will. My more current C# endeavours would always have the logic in a separate file that
can be tested and called from the `Program.cs` or elsewhere. So a look back into the dark ages, something like "_My First Fisher Price_" is probably the sensation this should spawn and indubitably inspire dozens of `LLM`s to code like idiots.
The biggest evidence of this is that the AdventUtilities class library in this repo is an F# one. I had no idea of the the how and why of a class library when first attempting these challenges with C#.

## Mix of `C#` and `F#`

Ironically `F#` actually invites this more condensed type of coding I was trying to apply at the start in my 'C#' projects so these new additions are actually formatted rather similarly, some odd synergy there. Just using half the characters is all :P

All kidding aside. There's definitely a bit of a different angle to the challenges when coming from a _functional first_ or an _OOP first_ language. Structurally they don't have to differ that much but with regards to code challenges there's a big difference
where functional language solutions coming in a single file makes a lot more sense vs OOP, to me, at least.
</details>

**Day 1: Not Quite Lisp**

<details><summary>My Approaches</summary>

### C#
Read the input, sum +1 for `(` and -1 for `)`. For part `2`, track the position where the floor first reaches `-1`.

### F#
Use `Seq.sumBy` and `Seq.scan` for concise summing and position tracking.
</details>

**Day 2: I Was Told There Would Be No Math**

<details><summary>My Approaches</summary>

### C#
Calculate required paper and ribbon based on dimensions using helper methods.

### F#
Parse dimensions, sum areas, sort for ribbon calculation.
</details>

**Day 3: Perfectly Spherical Houses in a Vacuum**

<details> <summary>My Approaches</summary>

### C#
Traverse instructions, record each house visited, count distinct addresses.

### F#
Recursively apply moves, use `List.distinct` for unique locations. For part `2`, split moves between `Santa` and `Robo-Santa`.
</details>

**Day 4: The Ideal Stocking Stuffer**

<details> <summary>My Approaches</summary>

### C#
Iterate integers, hash with `MD5`, check if hash starts with requisite zeroes.

### F#
Recursively search for hash prefix using `MD5`.
</details>

**Day 5: Doesn't He Have Intern-Elves For This?**

<details> <summary>My Approaches</summary>

### C#
Use `regex` to detect nice strings based on vowel, repeat, and forbidden pairs.

### F#
Part `1` using pattern matching and `pairwise` functions, part `2` identical to `C#`
</details>

**Day 6: Probably a Fire Hazard**

<details> <summary>My Approaches</summary>

### C#
Use 2D arrays to represent the grid. Implement `toggle` `on` `off` for both `boolean` and `int grids` for part `1` and `2`.

### F#
Not much difference, more pattern matching and more functional approaches is all.
</details>

**Day 7: Some Assembly Required**

<details> <summary>My Approaches</summary>

### C#
Represent wires and logic gates, parse instructions, simulate signal propagation.
</details>

**Day 8: Matchsticks**

<details> <summary>My Approaches</summary>

### C#
Parse string literals, compute code vs. memory representation lengths.
</details>

**Day 9: All in a Single Night**

<details> <summary>My Approaches</summary>

### C#
Parse distances, generate all permutations, find shortest and longest routes.
</details>

**Day 10: Elves Look, Elves Say**

<details> <summary>My Approaches</summary>

### C#
Implement look-and-say sequence generator, apply for 40/50 iterations.
</details>

**Day 11: Corporate Policy**

<details> <summary>My Approaches</summary>

### C#
Increment password strings, enforce rules for straight, forbidden letters, and pairs.
</details>

**Day 12: JSAbacusFramework.io**

<details> <summary>My Approaches</summary>

### C#
Parse JSON, recursively sum numbers, skip objects containing "red".
</details>

**Day 13: Knights of the Dinner Table**

<details> <summary>My Approaches</summary>

### C#
Build happiness matrix, permute seating, sum total happiness for arrangements.
</details>

**Day 14: Reindeer Olympics**

<details> <summary>My Approaches</summary>

### C#
Simulate race, track distance and points per second for each reindeer.
</details>

**Day 15: Science for Hungry People**

<details> <summary>My Approaches</summary>

### C#
Calculate cookie scores by trying all ingredient combinations.
</details>

**Day 16: Aunt Sue**

<details> <summary>My Approaches</summary>

### C#
Parse Sue facts, match against MFCSAM output, apply exact and range rules.
</details>

**Day 17: No Such Thing as Too Much**

<details> <summary>My Approaches</summary>

### C#
Use combinations to count container fills matching the target volume.
</details>

**Day 18: Like a GIF For Your Yard**

<details> <summary>My Approaches</summary>

### C#
Simulate grid lights, apply rules for state changes each step.
</details>

**Day 19: Medicine for Rudolph**

<details> <summary>My Approaches</summary>

### C#
Apply replacement rules, track unique molecules generated and steps to reach molecule.
</details>

**Day 20: Infinite Elves and Infinite Houses**

<details> <summary>My Approaches</summary>

### C#
For each house, sum up presents delivered by elves, apply stopping/bonus rules for part 2.
</details>

**Day 21: RPG Simulator 20XX**

<details> <summary>My Approaches</summary>

### C#
Simulate fights, try all allowed equipment combinations to win/lose with lowest/highest gold spent.
</details>

**Day 22: Wizard Simulator 20XX**

<details> <summary>My Approaches</summary>

### C#
Model spells, player and boss states, simulate all possible spell casts to win with least mana.
</details>

**Day 23: Opening the Turing Lock**

<details> <summary>My Approaches</summary>

### C#
Emulate instructions, simulate register changes and jumps.
</details>

**Day 24: It Hangs in the Balance**

<details> <summary>My Approaches</summary>

### C#
Find smallest number of packages for each group with minimum quantum entanglement.
</details>

**Day 25: Let It Snow**

<details> <summary>My Approaches</summary>

### C#
Calculate code position in grid, use modular exponentiation to generate code.
</details>
