using Day18;

#region Solution with Dictionary

// string filePath = @"..\Day18\example1.txt";
/* string filePath = @"..\Day18\input.txt";
string[] input = File.ReadAllLines(filePath);

int rows = input.Length;
int cols = input[0].Length;

Dictionary<(int, int), char> lightsStates = new();

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        lightsStates.Add((row, col), input[row][col]);
    }
}

//Part 2
(int, int) maxCoord = lightsStates.Max(pair => pair.Key);
List<(int, int)> corners = new() { (0, 0), (0, maxCoord.Item2), (maxCoord.Item1, 0), maxCoord };

foreach (var corner in corners)
{
    lightsStates[corner] = '#';
}

Light.DrawLightDict(lightsStates, rows, cols);
Console.WriteLine();

int index = 0;
while (index < 1000)
{
    lightsStates = Light.NewState(lightsStates);
    Console.Clear();
    Light.DrawLightDict(lightsStates, rows, cols);
    Thread.Sleep(50);

    // int lightsCount = lightsStates.Count(kvp => kvp.Value == '#');
    // Console.WriteLine(lightsCount);

    // Console.WriteLine();
    index++;
}

int lightsOn = lightsStates.Count(kvp => kvp.Value == '#');
Console.WriteLine(lightsOn); */

#endregion

#region Solution with 2D array

// string filePath = @"..\Day18\example1.txt";
string filePath = @"..\Day18\input.txt";
string[] input = File.ReadAllLines(filePath);

int rows = input.Length;
int cols = input[0].Length;

Dictionary<(int, int), char> lightsStates = new();
char[,] lightGrid = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        lightGrid[row, col] = input[row][col];
    }
}

//Part 2
/* (int, int) maxCoord = (lightGrid.GetLength(0) - 1, lightGrid.GetLength(1) - 1);
List<(int, int)> corners = new() { (0, 0), (0, maxCoord.Item2), (maxCoord.Item1, 0), maxCoord };

foreach (var corner in corners)
{
    lightGrid[corner.Item1, corner.Item2] = '#';
} */

Light.DrawLightGrid(lightGrid, rows, cols);
Console.WriteLine();

int index = 0;
while (index < 1000)
{
    lightGrid = Light.NewStateArray(lightGrid);
    Console.Clear();
    Light.DrawLightGrid(lightGrid, rows, cols);
    Thread.Sleep(200);
    index++;
}

int lightsOn = Light.CountLightsOn(lightGrid);
Console.WriteLine(lightsOn);

#endregion


