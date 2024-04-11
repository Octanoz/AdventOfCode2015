namespace Day18;

record Light(int Row, int Col)
{
    public static int CountLightsOn(char[,] grid)
    {
        int count = 0;
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                if (grid[row, col] == '#')
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static void DrawLightGrid(char[,] grid, int rows, int cols)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write($"{grid[row, col]} ");
            }
            Console.WriteLine();
        }
    }

    public static char[,] NewStateGrid(char[,] grid)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        char[,] newState = new char[rows, cols];

        int[] deltaRow = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] deltaCol = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int count = 0;

                for (int i = 0; i < 8; i++)
                {
                    int newRow = row + deltaRow[i];
                    int newCol = col + deltaCol[i];

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow, newCol] == '#')
                    {
                        count++;
                    }
                }

                if (grid[row, col] == '.')
                {
                    newState[row, col] = (count == 3) ? '#' : '.';
                }
                else if (grid[row, col] == '#')
                {
                    newState[row, col] = (count == 2 || count == 3) ? '#' : '.';
                }
            }
        }

        return newState;
    }
}