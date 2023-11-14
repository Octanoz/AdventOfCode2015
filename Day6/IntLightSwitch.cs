namespace Day6;

class IntLightSwitch
{
    public static void TurnOnRange(int[,] grid, (int, int) start, (int, int) end)
    {
        for (int y = start.Item2; y <= end.Item2; y++)
        {
            for (int x = start.Item1; x <= end.Item1; x++)
            {
                grid[y, x] += 1;
            }
        }
    }

    public static void TurnOffRange(int[,] grid, (int, int) start, (int, int) end)
    {
        for (int y = start.Item2; y <= end.Item2; y++)
        {
            for (int x = start.Item1; x <= end.Item1; x++)
            {
                grid[y, x] -= grid[y, x] > 0 ? 1 : 0;
            }
        }
    }

    public static void ToggleRange(int[,] grid, (int, int) start, (int, int) end)
    {
        for (int y = start.Item2; y <= end.Item2; y++)
        {
            for (int x = start.Item1; x <= end.Item1; x++)
            {
                grid[y, x] += 2;
            }
        }
    }
}