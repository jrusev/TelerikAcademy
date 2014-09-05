using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// We are given a matrix of passable and non-passable cells.
// Write a recursive program for finding all paths between two cells in the matrix.
internal class AllPathsInLabyrinth
{
    private const char Impassable = '#';
    private static string[] matrix;
    private static bool[,] visited;
    private static int rows;
    private static int cols;
    private static int[] dRow = { 1, -1, 0, 0 };
    private static int[] dCol = { 0, 0, 1, -1 };

    private static int startRow;
    private static int startCol;
    private static int endRow;
    private static int endCol;

    private static int count = 0;

    private static string test001 = @"6
S#######
.#.....#
...#.#.#
#.##.#.#
#....#.#
####...E
";

    internal static void Main()
    {
        Console.SetIn(new StringReader(test001));

        matrix = ParseMatrix();
        rows = matrix.GetLength(0);
        cols = matrix[0].Length;
        visited = new bool[rows, cols];

        startRow = 0;
        startCol = 0;
        endRow = rows - 1;
        endCol = cols - 1;

        FindAllPaths(startRow, startCol, new Stack<Tuple<int, int>>());
        Console.WriteLine("There are {0} paths between the upper-left and lower-right cell.", count);
    }

    private static void FindAllPaths(int row, int col, Stack<Tuple<int, int>> path)
    {
        path.Push(new Tuple<int, int>(row, col));
        visited[row, col] = true;

        if (row == endRow && col == endCol)
        {
            Console.WriteLine(string.Join(string.Empty, path.Reverse()));
            count++;
        }
        else 
        {
            for (int dir = 0; dir < 4; dir++)
            {
                int nextRow = row + dRow[dir];
                int nextCol = col + dCol[dir];
                if (IsInsideMatrix(nextRow, nextCol) &&
                    matrix[nextRow][nextCol] != Impassable &&
                    !visited[nextRow, nextCol])
                {
                    FindAllPaths(nextRow, nextCol, path);
                }
            }
        }

        visited[row, col] = false;
        path.Pop();
    }

    private static bool IsInsideMatrix(int row, int col)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }

    private static string[] ParseMatrix()
    {
        int rows = int.Parse(Console.ReadLine());
        var matrix = new string[rows];
        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine();
            Console.WriteLine(matrix[row]);
        }

        return matrix;
    }
}