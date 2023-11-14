#region Solution 1

/* // string filePath = @"..\Day19\example1.txt";
string filePath = @"..\Day19\input.txt";
string[] input = File.ReadAllLines(filePath);

Dictionary<string, List<string>> replacementMolecules = new();
HashSet<string> replacementStringSet = new();
string origin = "";

foreach (var line in input)
{
    if (line == "")
        continue;

    if (line.Contains(" => "))
    {
        string[] parts = line.Split(" => ");

        if (!replacementMolecules.TryAdd(parts[0], new List<string>() { parts[1] }))
            replacementMolecules[parts[0]].Add(parts[1]);
    }
    else origin = new string(line);
}

foreach (var kvp in replacementMolecules)
{
    Console.Write("[");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write($"{kvp.Key} = ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"{String.Join(", ", kvp.Value)}]");
    Console.WriteLine();
}

for (int i = 0; i < origin.Length; i++)
{
    string sub = "";
    int currentIndex = i;

    if (Char.IsAsciiLetterUpper(origin[i]))
    {
        sub += origin[i];

        while (i < origin.Length - 1 && Char.IsAsciiLetterLower(origin[i + 1]))
        {
            sub += origin[++i];
        }

        if (replacementMolecules.ContainsKey(sub))
        {
            foreach (var replacement in replacementMolecules[sub])
            {
                string temp = origin.Remove(currentIndex, i + 1 - currentIndex);
                temp = temp.Insert(currentIndex, replacement);
                replacementStringSet.Add(new string(temp));
            }
        }
    }

    i = currentIndex;
}

Console.WriteLine($"Total number of distinct molecules = {replacementStringSet.Count}"); */

#endregion

#region Alternative Solution 1

// string filePath = @"..\Day19\example1.txt";
// string filePath = @"..\Day19\example2.txt";
string filePath = @"..\Day19\input.txt";
string[] input = File.ReadAllLines(filePath);

List<string[]> replacements = input.Select(s => s.Split(" => "))
                                    .Where(a => a.Length == 2)
                                    .Select(a => new[] { a[0], a[1] })
                                    .ToList();

string origin = input[^1];

//Part 1
/* int distinctMolecules = Mutate(origin, replacements).Distinct().Count();
Console.WriteLine(distinctMolecules); */

int steps = Search(origin, replacements);

Console.WriteLine($"Steps necessary: {steps}");


IEnumerable<string> Mutate(string origin, IEnumerable<string[]> replacements)
{
    return from pos in Enumerable.Range(0, origin.Length)
           from rep in replacements
           let a = rep[0]
           let b = rep[1]
           where origin[pos..].StartsWith(a)
           select string.Concat(origin.AsSpan(0, pos), b, origin.AsSpan(pos + a.Length));
}

int Search(string molecule, IEnumerable<string[]> replacements)
{
    string target = molecule;
    int mutations = 0;

    while (target != "e")
    {
        string temp = target;

        foreach (var rep in replacements)
        {
            string a = rep[0];
            string b = rep[1];
            int index = target.IndexOf(b);

            if (index >= 0)
            {
                target = string.Concat(target.AsSpan(0, index), a, target.AsSpan(index + b.Length));
                mutations++;
            }
        }

        if (temp == target)
        {
            target = molecule;
            mutations = 0;
            replacements = Shuffle(replacements).ToList();
        }
    }

    return mutations;
}

static IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
{
    Random random = new();
    return source.OrderBy<T, int>((item) => random.Next());
}

#endregion

