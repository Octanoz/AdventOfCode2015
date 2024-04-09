using MoreLinq;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day3\example1.txt",
    ["challenge"] = @"..\Day3\input.txt"
};

Console.WriteLine($"{PartOne(filePaths["challenge"])} houses received at least one present.");
Console.WriteLine($"Using MoreLinq for part one gives {PartOneMoreLinq(filePaths["challenge"])} houses that receive at least one present.");
Console.WriteLine();
Console.WriteLine($"When Santa and Robo-Santa work together, {PartTwo(filePaths["challenge"])} houses receive at least one present.");

//? north (^), south (v), east (>), or west (<)

int PartOne(string filePath)
{
    string[] input = File.ReadAllLines(filePath);

    Dictionary<(int, int), int> coordinates = new()
    {
        [(0, 0)] = 1
    };

    (int, int) nextCoord = (0, 0);
    foreach (var line in input)
    {
        for (int i = 0; i < line.Length; i++)
        {
            nextCoord = line[i] switch
            {
                '^' => (nextCoord.Item1, nextCoord.Item2 - 1),
                '>' => (nextCoord.Item1 + 1, nextCoord.Item2),
                'v' => (nextCoord.Item1, nextCoord.Item2 + 1),
                '<' => (nextCoord.Item1 - 1, nextCoord.Item2),
                _ => throw new ArgumentException("Unknown character")
            };

            if (!coordinates.TryAdd(nextCoord, 1))
                coordinates[nextCoord]++;
        }
    }

    return coordinates.Count;
}

int PartTwo(string filePath)
{
    string[] input = File.ReadAllLines(filePath);

    Dictionary<(int, int), int> coordinates = new()
    {
        [(0, 0)] = 2
    };

    (int, int) santa = (0, 0);
    (int, int) roboSanta = (0, 0);
    foreach (var line in input)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (i % 2 == 0)
            {
                santa = line[i] switch
                {
                    '^' => (santa.Item1, santa.Item2 - 1),
                    '>' => (santa.Item1 + 1, santa.Item2),
                    'v' => (santa.Item1, santa.Item2 + 1),
                    '<' => (santa.Item1 - 1, santa.Item2),
                    _ => throw new ArgumentException("Unknown character")
                };

                if (!coordinates.TryAdd(santa, 1))
                    coordinates[santa]++;
            }
            else
            {
                roboSanta = line[i] switch
                {
                    '^' => (roboSanta.Item1, roboSanta.Item2 - 1),
                    '>' => (roboSanta.Item1 + 1, roboSanta.Item2),
                    'v' => (roboSanta.Item1, roboSanta.Item2 + 1),
                    '<' => (roboSanta.Item1 - 1, roboSanta.Item2),
                    _ => throw new ArgumentException("Unknown character")
                };

                if (!coordinates.TryAdd(roboSanta, 1))
                    coordinates[roboSanta]++;
            }
        }
    }

    return coordinates.Count;
}

int PartOneMoreLinq(string filePath) => File.ReadAllText(filePath)
                                            .Scan(new { X = 0, Y = 0 }, (state, c) =>
                                                c == '>' ? new { X = state.X + 1, state.Y } :
                                                c == '^' ? new { state.X, Y = state.Y + 1 } :
                                                c == '<' ? new { X = state.X - 1, state.Y } :
                                                            new { state.X, Y = state.Y - 1 })
                                            .Select(p => $"{p.X},{p.Y}")
                                            .GroupBy(p => p)
                                            .Count();
