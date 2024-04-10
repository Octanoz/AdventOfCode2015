using System.Text.RegularExpressions;

string filePath = @"..\Day16\input.txt";
string[] input = File.ReadAllLines(filePath);

Console.WriteLine($"The Sue that got me the gift is: ");
PartOne(input);
Console.WriteLine();

Console.WriteLine($"The real aunt Sue that got me the gift is: {FindSue(input, true)}");

void PartOne(string[] input)
{
    Regex allMatch = new(@"/([A-Z]\w+\s\d{1,3})|(children: 3)|(cats: 7)|(samoyeds: 2)|(pomerians: 3)|(akitas: 0)|(vizslas: 0)|(goldfish: 5)|(trees: 3)|(cars: 2)|(perfumes: 1)[,\n]");

    foreach (var line in input)
    {
        if (allMatch.Matches(line).Count == 3)
        {
            Console.WriteLine(line);
            break;
        }
    }
}

int FindSue(string[] input, bool isPartTwo = false)
{
    //Using dictionary instead of straight regex
    Dictionary<string, int> target = new()
    {
        ["children"] = 3,
        ["cats"] = 7,
        ["samoyeds"] = 2,
        ["pomeranians"] = 3,
        ["akitas"] = 0,
        ["vizslas"] = 0,
        ["goldfish"] = 5,
        ["trees"] = 3,
        ["cars"] = 2,
        ["perfumes"] = 1,
    };

    Dictionary<string, int>[] sues = input.Select(r => Regex.Matches(r, @"(\w+): (\d+)")
                                                .Cast<Match>()
                                                .Select(match => match.Groups
                                                .Cast<Group>()
                                                .Select(group => group.Value)
                                                .Skip(1)
                                                .ToArray())
                                            .ToDictionary(group => group[0], group => int.Parse(group[1])))
                                            .ToArray();

    if (!isPartTwo)
    {
        var result = sues.Select((s, n) => new
        {
            Sue = n + 1,
            Match = target.All(kvp => !s.ContainsKey(kvp.Key) || s[kvp.Key] == kvp.Value)
        }).Single(sue => sue.Match);

        return result.Sue;
    }
    else
    {
        var result2 = sues.Select((s, n) => new
        {
            Sue = n + 1,
            Match = s.All(kvp =>
            (kvp.Key == "cats" || kvp.Key == "trees") ? target[kvp.Key] < kvp.Value :
            (kvp.Key == "pomeranians" || kvp.Key == "goldfish") ? target[kvp.Key] > kvp.Value :
            target[kvp.Key] == kvp.Value)
        }).Single(sue => sue.Match);

        return result2.Sue;
    }
}