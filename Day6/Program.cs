using System.Text.RegularExpressions;
using Day6;

string filePath = @"..\Day6\input.txt";
string[] input = File.ReadAllLines(filePath);

Console.WriteLine($"In part one, {PartOne(input)} lights are lit.");
Console.WriteLine($"In part two, the total brightness is {PartTwo(input)}.");

int PartOne(string[] input)
{
    Regex regex = new(@"(\d+)[,\s]?");

    bool[,] lightGrid = new bool[1000, 1000];

    foreach (var line in input)
    {
        var coords = regex.Matches(line).Cast<Match>().Select(match => int.Parse(match.Groups[1].Value)).ToArray();
        (int, int) start = (coords[0], coords[1]);
        (int, int) end = (coords[2], coords[3]);

        if (line.StartsWith("turn on"))
        {
            LightSwitch.TurnOnRange(lightGrid, start, end);
        }
        else if (line.StartsWith("turn off"))
        {
            LightSwitch.TurnOffRange(lightGrid, start, end);
        }
        else
        {
            LightSwitch.ToggleRange(lightGrid, start, end);
        }
    }

    return lightGrid.Cast<bool>().Count(b => b);
}


int PartTwo(string[] input)
{
    Regex regex = new(@"(\d+)[,\s]?");

    int[,] lightGrid = new int[1000, 1000];

    foreach (var line in input)
    {
        int[] coords = regex.Matches(line).Cast<Match>().Select(match => int.Parse(match.Groups[1].Value)).ToArray();
        (int, int) start = (coords[0], coords[1]);
        (int, int) end = (coords[2], coords[3]);

        if (line.StartsWith("turn on"))
        {
            IntLightSwitch.TurnOnRange(lightGrid, start, end);
        }
        else if (line.StartsWith("turn off"))
        {
            IntLightSwitch.TurnOffRange(lightGrid, start, end);
        }
        else
        {
            IntLightSwitch.ToggleRange(lightGrid, start, end);
        }
    }

    return lightGrid.Cast<int>().Sum();
}