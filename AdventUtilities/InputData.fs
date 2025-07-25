namespace AdventUtilities

open System.IO

type InputData() =
    member this.GetSolutionDirectory() =
        let rec findSolutionDirectory dir =
            let solutionFile = Path.Combine(dir, "AoC2015.sln")

            if File.Exists solutionFile then
                dir
            else
                let parentDir = Directory.GetParent dir

                if parentDir = null then
                    failwith "Solution directory not found"
                else
                    findSolutionDirectory parentDir.FullName

        findSolutionDirectory (Directory.GetCurrentDirectory())

    member this.GetFilePath day fileName =
        let basePath = Path.Combine(this.GetSolutionDirectory())
        let printName = $"Day%02d{day}F/%s{fileName}.txt"
        Path.Combine(basePath, printName)

    member this.GetNonTextFilePath day fileName =
        let basePath = Path.Combine(this.GetSolutionDirectory())
        let printName = $"Day%02d{day}F/%s{fileName}"
        Path.Combine(basePath, printName)

    member this.ReadAllLines day fileName =
        let filePath = this.GetFilePath day fileName
        File.ReadAllLines filePath

    member this.ReadAllText day fileName =
        let filePath = this.GetFilePath day fileName
        File.ReadAllText filePath

    member this.ReadWithStreamReader day fileName =
        let filePath = this.GetFilePath day fileName

        seq {
            use sr = new StreamReader(filePath)

            while not sr.EndOfStream do
                yield sr.ReadLine()
        }
