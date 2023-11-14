using System.Text.RegularExpressions;
using Day14;

// string filePath = @"..\Day14\example1.txt";
string filePath = @"..\Day14\input.txt";
string[] input = File.ReadAllLines(filePath);
Regex parameters = new(@"([A-Z]\w+)|(\d+)");
Dictionary<Deer, int> points = new();

foreach (var line in input)
{
    string[] parts = parameters.Matches(line).Cast<Match>().Select(match => match.Value).ToArray(); // [name] [speed] [moveTime] [restTime]
    Deer deer = new(parts[0], float.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
    points.Add(deer, 0);
}

// int duration = 1000;
int duration = 2503;
foreach (var deer in points)
{
    int seconds = 0;
    float distance = 0f;

    while (seconds <= duration)
    {
        int moveDuration = seconds + deer.Key.Times["move"];

        while (seconds < moveDuration && seconds <= duration)
        {
            seconds++;
            distance += deer.Key.Speed;
            deer.Key.TravelledPerSecond[seconds] = distance;
        }

        int restDuration = seconds + deer.Key.Times["rest"];

        while (seconds < restDuration && seconds <= duration)
        {
            seconds++;
            deer.Key.TravelledPerSecond[seconds] = distance;
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

    foreach (var deer in points)
    {
        if (deer.Key.TravelledPerSecond[index] == maxDistance)
            points[deer.Key]++;
    }
}

foreach (var deer in points)
{
    Console.WriteLine($"[{deer.Key.Name}, {deer.Value}]");
}

//? 520 is too low

