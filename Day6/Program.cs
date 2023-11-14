#region Solution 1

/* using System.Text.RegularExpressions;
using Day6;

string filePath = @"..\Day6\input.txt";
string[] input = File.ReadAllLines(filePath);
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


int lightOn = lightGrid.Cast<bool>().Count(x => x);
Console.WriteLine(lightOn); */

#endregion

#region Solution 2

using System.Text.RegularExpressions;
using Day6;

string filePath = @"..\Day6\input.txt";
string[] input = File.ReadAllLines(filePath);
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

int brightness = lightGrid.Cast<int>().Sum();
Console.WriteLine(brightness);

#endregion
