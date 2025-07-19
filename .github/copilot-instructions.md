# Copilot Instructions for AdventOfCode 2015 Codebase

## Overview
This repository contains solutions for Advent of Code 2015, organized by day and language. F# solutions are in folders ending with `F` (e.g., `Day01F`). Agents should focus exclusively on F# projects. Utilities are shared via the `AdventUtilities` library.

## Architecture & Structure
-- **Per-Day Projects:** Each F# day (e.g., `Day01F`, `Day02F`, etc.) is a standalone project, with its own `Program.fs`, input data, and instructions. C# day folders (not ending with `F`) should only be used as sources for copying `Instructions.md`, `input.txt`, and `example*.txt` files into the corresponding F# folder if needed. Do not modify or analyze C# code.
-- **Shared Utilities:** The `AdventUtilities` directory contains reusable helpers (e.g., `Helpers.fs`, `InputData.fs`, `TryParser.fs`). F# projects reference this for common logic.
-- **Inputs & Instructions:** Each F# day folder includes `input.txt` (real puzzle input), `example*.txt` (sample data), and `Instructions.md` (puzzle description). These files may be copied from the corresponding C# folder, but their contents must remain unchanged.

## Developer Workflows
**Build and Run F# Projects:**
  - Use `dotnet build AoC2015.sln` to build all solutions, focusing on F# projects.
  - Use the VS Code task labeled `build` for convenience.
  - Use `dotnet run --project <FSharpProjectPath>` for a specific F# day.
  - Ensure `AdventUtilities` is built and referenced for F# projects.
  - Use the VS Code task labeled `watch` to run F# solutions interactively.

## Patterns & Conventions
**Input Handling:**
  - Input files for F# projects are loaded using utility functions (see `InputData.fs`). Example: `let filePath = inputData.GetFilePath 1 "input"`.
**Solution Structure:**
  - Each F# `Program.fs` file typically has two parts: Part 1 and Part 2, matching the Advent of Code format.
  - Example:
    ```fsharp
    input |> Seq.sumBy (fun c -> if c = '(' then 1 else -1) |> printfn "Part 1: Floor %i"
    input |> Seq.scan (fun acc c -> acc + if c = '(' then 1 else -1) 0 |> Seq.findIndex ((=) -1) |> printfn "Part 2: First basement instruction at position %i"
    ```
**Cross-Project Utilities:**
  - Reference `AdventUtilities` for shared logic in F# projects only.
**Instructions & Examples:**
  - Always check `Instructions.md` and `example*.txt` in the F# folder for context and test cases. These may be copied from the C# folder, but do not modify their contents.

## External Dependencies
- **.NET SDK:** All projects use .NET Core/SDK. No non-standard dependencies detected.
**No Custom Build Scripts:** All builds and runs are via standard `dotnet` commands or VS Code tasks, focused on F# projects.

## Integration Points
- **No External Services:** Solutions are self-contained, focused on algorithmic puzzles.
**No Inter-Project Communication:** Each F# day is independent, except for shared utilities.

## Key Files & Directories
- `AoC2015.sln` – Solution file for all projects
- `AdventUtilities/` – Shared F# utilities
-- `DayXXF/` – Per-day F# solution folders
- `Instructions.md`, `input.txt`, `example*.txt` – Per-day documentation and data

---
**For AI agents:**
- Only work with F# projects (folders ending with `F`).
- Do not analyze, modify, or generate code for C# projects (folders not ending with `F`).
- You may copy `Instructions.md`, `input.txt`, and `example*.txt` from C# folders to the corresponding F# folder, but do not change their contents.
- Prefer using existing utility functions for input and parsing in F#.
- Follow the per-day F# project structure for new solutions.
- Use provided VS Code tasks for build/run workflows.
- Reference `Instructions.md` and examples in the F# folder for expected behavior.

If any section is unclear or missing details, please provide feedback for further refinement.
