using System.Text.RegularExpressions;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day5\example1.txt",
    ["challenge"] = @"..\Day5\input.txt"
};

Console.WriteLine($"In part one {PartOne(filePaths["challenge"])} strings were nice.");
Console.WriteLine($"In part two {PartTwo(filePaths["challenge"])} strings were nice.");

int PartOne(string filePath)
{
    string[] input = File.ReadAllLines(filePath);

    Regex badPairs = new(@"(ab)|(cd)|(pq)|(xy)");
    Regex threeVowels = new(@"(?:.*[aeiou].*){3,}");
    Regex repeatingCharacter = new(@"(.)\1");

    int naughty = 0;
    int nice = 0;
    foreach (var line in input)
    {
        if (badPairs.IsMatch(line))
        {
            naughty++;
            continue;
        }

        if (threeVowels.IsMatch(line) && repeatingCharacter.IsMatch(line))
        {
            nice++;
        }
        else naughty++;

    }

    Console.WriteLine($"Naugthy: {naughty}, Nice: {nice}");
    return nice;
}

int PartTwo(string filePath)
{
    string[] input = File.ReadAllLines(filePath);

    Regex repeatingPairs = new(@"(..).*\1");
    Regex repeatingCharacter = new(@"(.).\1");

    int naughty = 0;
    int nice = 0;
    foreach (var line in input)
    {
        if (repeatingPairs.IsMatch(line) && repeatingCharacter.IsMatch(line))
        {
            nice++;
        }
        else naughty++;
    }

    Console.WriteLine($"Naugthy: {naughty}, Nice: {nice}");
    return nice;
}
