using System;

// Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
internal class LargestConnectedArea
{
    private const char Impassable = '#';
    private static string[] matrix;
    private static bool[,] visited;
    private static int rows;
    private static int cols;

    private static int[] dRow = { 1, 0, -1, 0 };
    private static int[] dCol = { 0, 1, 0, -1 };

    internal static void Main()
    {
        matrix = new[] 
        {
            "##################",
            "#.##.##.##...##..#",
            "####.##.##.#.##..#",
            "#######.##...#####",
            "##################",
        };

        Console.WriteLine("The matrix:");
        Console.WriteLine(string.Join(Environment.NewLine, matrix));

        rows = matrix.Length;
        cols = matrix[0].Length;
        visited = new bool[rows, cols];

        int maxCount = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row][col] != Impassable && !visited[row, col])
                {
                    int count = FindConnectedArea(row, col);
                    maxCount = Math.Max(maxCount, count);
                    Console.WriteLine("{0, 2} cells", count);
                }
            }
        }

        Console.WriteLine("The largest area consists of {0} cells.", maxCount);
    }

    private static int FindConnectedArea(int row, int col)
    {
        visited[row, col] = true;
        int count = 1;
        for (int dir = 0; dir < 4; dir++)
        {
            int nextRow = row + dRow[dir];
            int nextCol = col + dCol[dir];
            if (IsInsideMatrix(nextRow, nextCol) &&
                matrix[nextRow][nextCol] != Impassable &&
                !visited[nextRow, nextCol])
            {
                count += FindConnectedArea(nextRow, nextCol);
            }
        }

        return count;
    }

    private static bool IsInsideMatrix(int row, int col)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }
}