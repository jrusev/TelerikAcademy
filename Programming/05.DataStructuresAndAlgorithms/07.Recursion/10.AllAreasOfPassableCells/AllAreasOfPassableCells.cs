using System;
using System.Collections.Generic;

// We are given a matrix of passable and non-passable cells.
// Write a recursive program for finding all areas of passable cells in the matrix.
internal class AllAreasOfPassableCells
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
            "###################################",
            "#...###..##...##...##.#.##...##...#",
            "#.#.####.####.####.##.#.##.####.#.#",
            "#.#.####.##...###..##...##...##...#",
            "#.#.####.##.######.####.##.#.##.#.#",
            "#...####.##...##...####.##...##...#",
            "###################################",
        };

        Console.WriteLine("The matrix:");
        Console.WriteLine(string.Join(Environment.NewLine, matrix));

        rows = matrix.Length;
        cols = matrix[0].Length;
        visited = new bool[rows, cols];

        Console.WriteLine("Areas found:");
        int top = Console.CursorTop;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row][col] != Impassable && !visited[row, col])
                {
                    var area = FindConnectedArea(row, col, new Stack<Tuple<int, int>>());
                    DrawArea(area, top);
                }
            }
        }
    }

    private static Stack<Tuple<int, int>> FindConnectedArea(int row, int col, Stack<Tuple<int, int>> area)
    {
        area.Push(new Tuple<int, int>(row, col));
        visited[row, col] = true;
        for (int dir = 0; dir < 4; dir++)
        {
            int nextRow = row + dRow[dir];
            int nextCol = col + dCol[dir];
            if (IsInsideMatrix(nextRow, nextCol) &&
                matrix[nextRow][nextCol] != Impassable &&
                !visited[nextRow, nextCol])
            {
                FindConnectedArea(nextRow, nextCol, area);
            }
        }

        return area;
    }

    private static bool IsInsideMatrix(int row, int col)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }

    private static void DrawArea(Stack<Tuple<int, int>> area, int top)
    {
        Console.BackgroundColor = Console.ForegroundColor;
        while (area.Count > 0)
        {
            var cell = area.Pop();
            Console.SetCursorPosition(cell.Item2, cell.Item1 + top);
            Console.Write(" ");
        }

        Console.SetCursorPosition(0, top + rows);
        Console.ResetColor();
    }
}