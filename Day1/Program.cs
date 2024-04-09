using MoreLinq;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day1\example1.txt",
    ["challenge"] = @"..\Day1\input.txt"
};

Console.WriteLine($"The instructions bring us to floor: {PartOne(filePaths["challenge"])}");
Console.WriteLine($"The position of the character that causes Santa to first enter the basement is: {PartTwo(filePaths["challenge"])}");
Console.WriteLine($"Using MoreLinq for the second part gives: {PartTwoMoreLinq(filePaths["challenge"])}");

int PartOne(string filePath) => File.ReadAllText(filePath).Sum(c => c == '(' ? 1 : -1);

int PartTwo(string filePath)
{
    string[] input = File.ReadAllLines(filePath);

    Stack<char> openingP = new();
    Stack<char> closingP = new();

    string line = input[0];

    for (int i = 0; i < line.Length; i++)
    {
        if (line[i] == '(')
        {
            openingP.Push(line[i]);
        }
        else closingP.Push(line[i]);

        if (openingP.Count - closingP.Count == -1)
        {
            return i + 1;
        }
    }

    return -1;
}

int PartTwoMoreLinq(string filePath) => File.ReadAllText(filePath)
                                            .Scan(0, (f, c) => c == '(' ? f + 1 : f - 1)
                                            .Select((Floor, Index) => new { Floor, Index })
                                            .First(f => f.Floor == -1).Index;