
#region Solution 1

/* //? north (^), south (v), east (>), or west (<)

// string filePath = @"..\Day3\example1.txt";
string filePath = @"..\Day3\input.txt";
string[] input = File.ReadAllLines(filePath);

foreach (var line in input)
{
    Dictionary<(int, int), int> coordinates = new()
    {
        [(0, 0)] = 1
    };
    (int, int) nextCoord = (0, 0);

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

    /* Console.WriteLine($"\n Duplicates: ");
    foreach (var kvp in coordinates)
    {
        if (kvp.Value > 1)
            Console.WriteLine(kvp);
    }

    int duplicates = coordinates.Count(x => x.Value > 1);
    Console.WriteLine(duplicates);
    Console.WriteLine($"Unique coordinates: {coordinates.Count}");
    Console.WriteLine("================");

} */

#endregion

#region Solution 2

//? north (^), south (v), east (>), or west (<)

/* // string filePath = @"..\Day3\example1.txt";
// string filePath = @"..\Day3\example2.txt";
string filePath = @"..\Day3\input.txt";
string[] input = File.ReadAllLines(filePath);

foreach (var line in input)
{
    Dictionary<(int, int), int> coordinates = new()
    {
        [(0, 0)] = 2
    };
    (int, int) santa = (0, 0);
    (int, int) roboSanta = (0, 0);

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
    } */

/* Console.WriteLine($"\n Duplicates: ");
foreach (var kvp in coordinates)
{
    if (kvp.Value > 1)
        Console.WriteLine(kvp);
} */

// int duplicates = coordinates.Count(x => x.Value > 1);
// Console.WriteLine(duplicates);
// Console.WriteLine($"Unique coordinates: {coordinates.Count}");
// Console.WriteLine("================");
// }

#endregion

#region MoreLinq Solution 1

using MoreLinq;

string filePath = @"..\Day3\input.txt";
int duplicates = File.ReadAllText(filePath).Scan(new { X = 0, Y = 0 }, (state, c) =>
                                                    c == '>' ? new { X = state.X + 1, state.Y } :
                                                    c == '^' ? new { state.X, Y = state.Y + 1 } :
                                                    c == '<' ? new { X = state.X - 1, state.Y } :
                                                                new { state.X, Y = state.Y - 1 })
                                                    .Select(p => $"{p.X},{p.Y}")
                                                    .GroupBy(p => p)
                                                    .Count();

Console.WriteLine(duplicates);

#endregion