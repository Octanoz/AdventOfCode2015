// #define VISUALIZE

using System.Text.RegularExpressions;
using Day14;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day14\example1.txt",
    ["challenge"] = @"..\Day14\input.txt"
};

Dictionary<string, int> durations = new()
{
    ["1k"] = 1000,
    ["challenge"] = 2503
};

string[] input = File.ReadAllLines(filePaths["challenge"]);

Deer fastestDeer = PartOne(input, durations["challenge"]);
Console.WriteLine($"The furthest travelling reindeer in {durations["challenge"]} seconds is {fastestDeer.Name}, travelling {fastestDeer.TravelledPerSecond[durations["challenge"]]} km.");

(Deer winner, int points) = PartTwo(input, durations["challenge"]);
Console.WriteLine($"The reindeer with the most points after {durations["challenge"]} seconds is {winner.Name}, with {points} points.");


Deer PartOne(string[] input, int duration)
{
    Regex parameters = new(@"([A-Z]\w+)|(\d+)");
    List<Deer> deerList = new();

    foreach (var line in input)
    {
        string[] parts = parameters.Matches(line).Cast<Match>().Select(match => match.Value).ToArray(); // [name] [speed] [moveTime] [restTime]
        Deer deer = new(parts[0], float.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
        deerList.Add(deer);
    }

    foreach (var deer in deerList)
    {
        int seconds = 0;
        float distance = 0f;

        while (seconds <= duration)
        {
            int moveDuration = seconds + deer.Times["move"];

            while (seconds < moveDuration && seconds <= duration)
            {
                seconds++;
                distance += deer.Speed;
                deer.TravelledPerSecond[seconds] = distance;
            }

            int restDuration = seconds + deer.Times["rest"];

            while (seconds < restDuration && seconds <= duration)
            {
                seconds++;
                deer.TravelledPerSecond[seconds] = distance;
            }
        }
    }

    return deerList.OrderByDescending(deer => deer.TravelledPerSecond[duration]).First();
}

(Deer, int) PartTwo(string[] input, int duration)
{
    Regex parameters = new(@"([A-Z]\w+)|(\d+)");
    Dictionary<Deer, int> points = new();

    foreach (var line in input)
    {
        string[] parts = parameters.Matches(line).Cast<Match>().Select(match => match.Value).ToArray(); // [name] [speed] [moveTime] [restTime]
        Deer deer = new(parts[0], float.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
        points.Add(deer, 0);
    }

    foreach (var deer in points.Select(deer => deer.Key))
    {
        int seconds = 0;
        float distance = 0f;

        while (seconds <= duration)
        {
            int moveDuration = seconds + deer.Times["move"];

            while (seconds < moveDuration && seconds <= duration)
            {
                seconds++;
                distance += deer.Speed;
                deer.TravelledPerSecond[seconds] = distance;
            }

            int restDuration = seconds + deer.Times["rest"];

            while (seconds < restDuration && seconds <= duration)
            {
                seconds++;
                deer.TravelledPerSecond[seconds] = distance;
            }
        }
    }

    int index = 0;
    float maxDistance = 0;
    while (index < duration)
    {
        index++;
        foreach (var deer in points)
        {
            float deersDistance = deer.Key.TravelledPerSecond[index];
            maxDistance = deersDistance > maxDistance ? deersDistance : maxDistance;
        }

        foreach (var deer in points.Select(deer => deer.Key))
        {
            if (deer.TravelledPerSecond[index] == maxDistance)
                points[deer]++;
        }
    }

#if VISUALIZE
    foreach (var deer in points)
    {
        Console.WriteLine($"[{deer.Key.Name}, {deer.Value}]");
    }
#endif

    KeyValuePair<Deer, int> winningDeer = points.OrderByDescending(deer => deer.Value).First();

    return (winningDeer.Key, winningDeer.Value);
}