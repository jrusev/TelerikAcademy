using System;
using System.Collections.Generic;
using System.Linq;

// Modify the previous program to check whether a path exists between two cells without finding all possible paths.
// Test it over an empty 100 x 100 matrix.
internal class FindPathInLabyrinth
{
    private const char Impassable = '#';
    private static string[] matrix;
    private static bool[,] visited;
    private static int rows;
    private static int cols;

    private static int[] dRow = { 1, 0, -1, 0 };
    private static int[] dCol = { 0, 1, 0, -1 };

    private static int startRow;
    private static int startCol;
    private static int endRow;
    private static int endCol;

    internal static void Main()
    {
        matrix = new[] 
        {
            "S#####",
            ".#...#",
            "...#.#",
            "#.##.#",
            "#....#",
            "####.E",
        };

        rows = matrix.Length;
        cols = matrix[0].Length;
        visited = new bool[rows, cols];

        startRow = 0;
        startCol = 0;
        endRow = rows - 1;
        endCol = cols - 1;

        Console.WriteLine(string.Join(Environment.NewLine, matrix));
        bool found = FindPath(startRow, startCol, new Stack<Tuple<int, int>>());
        Console.WriteLine("A path {0} between the upper-left and lower-right cell.", found ? "exists" : "does not extist");
    }

    private static bool FindPath(int row, int col, Stack<Tuple<int, int>> path)
    {
        path.Push(new Tuple<int, int>(row, col));
        visited[row, col] = true;

        if (row == endRow && col == endCol)
        {
            Console.WriteLine(string.Join("->", path.Reverse()));
            return true;
        }

        for (int dir = 0; dir < 4; dir++)
        {
            int nextRow = row + dRow[dir];
            int nextCol = col + dCol[dir];
            if (IsInsideMatrix(nextRow, nextCol) &&
                matrix[nextRow][nextCol] != Impassable &&
                !visited[nextRow, nextCol])
            {
                if (FindPath(nextRow, nextCol, path))
                {
                    return true;
                }
            }
        }

        path.Pop();
        visited[row, col] = false;
        return false;
    }

    private static bool IsInsideMatrix(int row, int col)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }
}