using System;
using System.Collections.Generic;

// We are given a labyrinth, which consists of N x N squares and each of it can be passable (0) or not (x).
// Our hero Jack is in one of the squares (*).
// If Jack steps in a cell, which is on the edge of the labyrinth,
// he can go out from the labyrinth with one step.
// Write a program, which by a given labyrinth prints the minimal number of steps,
// which Jack needs, to go out from the labyrinth or -1 if there is no way out.
public class Program
{
    private static string[] matrix;
    private static bool[,] visited;
    private static int rows;
    private static int cols;
    private static int[] dRow = { 1, -1, 0, 0 };
    private static int[] dCol = { 0, 0, 1, -1 };

    public static void Main()
    {
        rows = int.Parse(Console.ReadLine());
        matrix = new string[rows];
        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine();
        }

        cols = matrix[0].Length;
        visited = new bool[rows, cols];

        var startCell = FindStartCell();
        int minSteps = FindMinSteps(startCell);
        Console.WriteLine(minSteps);
    }

    private static Cell FindStartCell()
    {
        int row, col;
        row = col = 0;
        for (row = 0; row < rows; row++)
        {
            col = matrix[row].IndexOf('*');
            if (col > -1)
            {
                break;
            }
        }

        return new Cell(row, col, 0);
    }

    private static int FindMinSteps(Cell startCell)
    {
        var queue = new Queue<Cell>();
        queue.Enqueue(startCell);

        while (queue.Count != 0)
        {
            var cell = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                var nextCell = new Cell(cell.Row + dRow[i], cell.Col + dCol[i], cell.Dist + 1);

                if (!IsInside(nextCell))
                    return cell.Dist + 1;                 

                if (IsPassable(nextCell) && !IsVisited(nextCell))
                    queue.Enqueue(nextCell);
            }

            visited[cell.Row, cell.Col] = true;
        }

        return -1;
    }

    private static bool IsVisited(Cell cell)
    {
        return visited[cell.Row, cell.Col];
    }

    private static bool IsPassable(Cell cell)
    {
        return matrix[cell.Row][cell.Col] == '0';
    }

    private static bool IsInside(Cell cell)
    {
        return cell.Row >= 0 && cell.Row < rows && cell.Col >= 0 && cell.Col < cols;
    }

    private struct Cell
    {
        public int Row, Col, Dist;

        public Cell(int row, int col, int dist)
            : this()
        {
            this.Row = row;
            this.Col = col;
            this.Dist = dist;
        }
    }
}
