using Day2;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day2\example1.txt",
    ["challenge"] = @"..\Day2\input.txt"
};

Console.WriteLine($"The elves should order {PartOne(filePaths["challenge"])} square feet of wrapping paper.");
Console.WriteLine($"The elves should order {PartTwo(filePaths["challenge"])} feet of ribbon.");


int PartOne(string filePath)
{
    string[] input = File.ReadAllLines(filePath);

    int total = 0;
    foreach (var line in input)
    {
        int[] dimensions = line.Split('x').Select(int.Parse).ToArray();

        int result = Wrapping.PaperNeeded(dimensions[0], dimensions[1], dimensions[2]);
        total += result;
    }

    return total;
}

int PartTwo(string filePath)
{
    string[] input = File.ReadAllLines(filePath);
    int total = 0;

    foreach (var line in input)
    {
        int[] dimensions = line.Split('x').Select(int.Parse).ToArray();

        int result = Wrapping.RibbonNeeded(dimensions[0], dimensions[1], dimensions[2]);
        total += result;
    }

    return total;
}
