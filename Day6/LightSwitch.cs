using System.Collections;

namespace Day6;

class LightSwitch
{

    #region BitArray
    static void TurnOnSingleBA(BitArray[] grid, (int, int) coord)
    {
        grid[coord.Item1].Set(coord.Item2, true);
    }

    static void TurnOffSingleBA(BitArray[] grid, (int, int) coord)
    {
        grid[coord.Item1].Set(coord.Item2, false);
    }

    static void ToggleSingleBA(BitArray[] grid, (int, int) coord)
    {
        grid[coord.Item1].Xor(new BitArray(new[] { 1 << coord.Item2 }));
    }

    #endregion

    public static void TurnOnRange(bool[,] grid, (int, int) start, (int, int) end)
    {
        for (int y = start.Item2; y <= end.Item2; y++)
        {
            for (int x = start.Item1; x <= end.Item1; x++)
            {
                grid[y, x] = true;
            }
        }
    }

    public static void TurnOffRange(bool[,] grid, (int, int) start, (int, int) end)
    {
        for (int y = start.Item2; y <= end.Item2; y++)
        {
            for (int x = start.Item1; x <= end.Item1; x++)
            {
                grid[y, x] = false;
            }
        }
    }

    public static void ToggleRange(bool[,] grid, (int, int) start, (int, int) end)
    {
        for (int y = start.Item2; y <= end.Item2; y++)
        {
            for (int x = start.Item1; x <= end.Item1; x++)
            {
                grid[y, x] ^= true;
            }
        }
    }


}