// #define VISUALIZE

using System.Text;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day19\example1.txt",
    ["example2"] = @"..\Day19\example2.txt",
    ["challenge"] = @"..\Day19\input.txt"
};

string[] input = File.ReadAllLines(filePaths["challenge"]);

Console.WriteLine($"Distinct molecules in part 1: {PartOne(input)}");

Console.WriteLine($"Distinct molecules in part 1, Linq solution: {LinqSolution(input)}");
Console.WriteLine($"The fewest number of steps needed to make the medicine molecule: {LinqSolution(input, true)}");



int PartOne(string[] input)
{
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

#if VISUALIZE

    foreach (var kvp in replacementMolecules)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{kvp.Key} = ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{String.Join(", ", kvp.Value)}]");
        Console.WriteLine();
    }

#endif

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

            if (replacementMolecules.TryGetValue(sub, out List<string>? storedList))
            {
                foreach (var replacement in storedList)
                {
                    string temp = origin.Remove(currentIndex, i + 1 - currentIndex);
                    temp = temp.Insert(currentIndex, replacement);
                    replacementStringSet.Add(new string(temp));
                }
            }
        }

        i = currentIndex;
    }

    return replacementStringSet.Count;
}

int LinqSolution(string[] input, bool isPartTwo = false)
{
    List<string[]> replacements = input.Select(s => s.Split(" => "))
                                        .Where(a => a.Length == 2)
                                        .Select(a => new[] { a[0], a[1] })
                                        .ToList();

    string origin = input[^1];

    if (isPartTwo)
    {
        return Search(origin, replacements);
    }
    else return Mutate(origin, replacements).Distinct().Count();
}

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


