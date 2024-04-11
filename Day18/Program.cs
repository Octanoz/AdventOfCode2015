// #define PART1
#define PART2
// #define VISUALIZE //Lots of flashing, probably want to leave this commented out if you're sensitive to that.

using Day18;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day18\example1.txt",
    ["challenge"] = @"..\Day18\input.txt"
};

Dictionary<string, int> steps = new()
{
    ["test1"] = 4,
    ["test2"] = 5,
    ["challenge"] = 100
};

string[] input = File.ReadAllLines(filePaths["challenge"]);

#if PART1
Console.WriteLine($"Number of lights on after {steps["challenge"]} steps: {NumberOfLightsOn2DGrid(input, steps["challenge"])}");
#elif PART2
Console.WriteLine($"Number of lights on after {steps["challenge"]} steps: {NumberOfLightsOn2DGrid(input, steps["challenge"], true)}");
#endif

int NumberOfLightsOn2DGrid(string[] input, int steps, bool isPartTwo = false)
{

    int rows = input.Length;
    int cols = input[0].Length;

    char[,] lightGrid = new char[rows, cols];

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            lightGrid[row, col] = input[row][col];
        }
    }

    if (isPartTwo)
    {
        (int, int) maxCoord = (lightGrid.GetLength(0) - 1, lightGrid.GetLength(1) - 1);
        List<(int, int)> corners = new() { (0, 0), (0, maxCoord.Item2), (maxCoord.Item1, 0), maxCoord };

        foreach (var corner in corners)
        {
            lightGrid[corner.Item1, corner.Item2] = '#';
        }

        int index = 0;
        while (index < steps)
        {
            lightGrid = Light.NewStateGrid(lightGrid);
            foreach (var corner in corners)
            {
                lightGrid[corner.Item1, corner.Item2] = '#';
            }

            index++;
        }
    }
    else
    {
        int index = 0;
        while (index < steps)
        {
            lightGrid = Light.NewStateGrid(lightGrid);

#if VISUALIZE
    Console.Clear();
    Light.DrawLightGrid(lightGrid, rows, cols);
    Thread.Sleep(200);
#endif
            index++;
        }
    }

    return Light.CountLightsOn(lightGrid);
}