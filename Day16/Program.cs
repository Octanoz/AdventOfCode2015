#region Solution 1

/* using System.Text.RegularExpressions;

string filePath = @"..\Day16\input.txt";
string[] input = File.ReadAllLines(filePath);

Regex allMatch = new(@"/([A-Z]\w+\s\d{1,3})|(children: 3)|(cats: 7)|(samoyeds: 2)|(pomerians: 3)|(akitas: 0)|(vizslas: 0)|(goldfish: 5)|(trees: 3)|(cars: 2)|(perfumes: 1)[,\n]");

foreach (var line in input)
{
    if (allMatch.Matches(line).Count == 3)
    {
        Console.WriteLine(line);
    }
} */

#endregion

#region Solution 2

/* using System.Text.RegularExpressions;

string filePath = @"..\Day16\input.txt";
string[] input = File.ReadAllLines(filePath);

Regex allMatch = new(@"/([A-Z]\w+\s\d{1,3})|(children: 3)|(cats: (?:8|9|10))|(samoyeds: 2)|(pomerians: [0-2])|(akitas: 0)|(vizslas: 0)|(goldfish: [0-4])(trees: (?:[4-9]|10))|(cars: 2)|(perfumes: 1)[,\n]");

foreach (var line in input)
{
    if (allMatch.Matches(line).Count == 2)
    {
        Console.WriteLine(line);
    }
} */


#endregion

//Using dictionary instead of straight regex
#region Solution 2 Alternative

using System.Text.RegularExpressions;

string filePath = @"..\Day16\input.txt";
string[] input = File.ReadAllLines(filePath);

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

//Part 1
/* var result = sues.Select((s, n) => new
{
    Sue = n + 1,
    Match = target.All(kvp => !s.ContainsKey(kvp.Key) || s[kvp.Key] == kvp.Value)
}).Single(sue => sue.Match); */

//Part 2
var result = sues.Select((s, n) => new
{
    Sue = n + 1,
    Match = s.All(kvp =>
    (kvp.Key == "cats" || kvp.Key == "trees") ? target[kvp.Key] < kvp.Value :
    (kvp.Key == "pomeranians" || kvp.Key == "goldfish") ? target[kvp.Key] > kvp.Value :
    target[kvp.Key] == kvp.Value)
}).Single(sue => sue.Match);


Console.WriteLine(result.Sue);

#endregion