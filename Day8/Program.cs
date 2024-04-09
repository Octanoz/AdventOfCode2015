using System.Text.RegularExpressions;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day8\example1.txt",
    ["challenge"] = @"..\Day8\input.txt"
};

string[] input = File.ReadAllLines(filePaths["challenge"]);

Console.WriteLine($"The number of characters of code for string literals minus the number of characters in memory is {PartOne(input)}");
Console.WriteLine($"The total number of characters in the newly encoded strings is {PartTwo(input)}");
int PartOne(string[] input)
{
    Regex all = new(@"(\\"")(?<!""$)|(\\\\)|(\\x[0-f]{2})");

    int total = 0;
    foreach (var line in input)
    {
        int len = line.Length;
        string correctedString = all.Replace(line, "z");
        int inMemory = correctedString.Length - 2;

        total += len - inMemory;
    }

    return total;
}

int PartTwo(string[] input)
{
    Regex accent = new(@"(\\"")(?<!""$)");
    Regex slash = new(@"(\\)");

    int total = 0;
    foreach (var line in input)
    {
        string newLine = accent.Replace(line, "1234");
        newLine = slash.Replace(newLine, "12");
        int encoded = 4 + (newLine.Length - line.Length);

        total += encoded;
    }

    return total;
}
