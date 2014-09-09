using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// You are given a labyrinth, which consists of N x N squares, each of it can be passable or not.
// Passable cells consist of lower Latin letter between "a" and "z", and the non-passable – '#'.
// In one of the squares is Jack. It is marked with "*".
// Two squares are neighbors, if they have common wall.
// At one step Jack can pass from one passable square to its neighboring passable square.
// When Jack passes through passable squares, he writes down the letters from each square.
// At each exit he gets a word. Write a program, which from a given labyrinth prints the words, which Jack gets from all the possible exits.
public class Program
{
    private const char Impassable = '#';
    private const char StartCell = '*';
    private static string[] matrix;
    private static bool[,] visited;
    private static int rows;
    private static int cols;
    private static int[] dRow = { 1, -1, 0, 0 };
    private static int[] dCol = { 0, 0, 1, -1 };

    private static readonly StringBuilder WordBuffer = new StringBuilder();
    private static readonly List<string> AllWords = new List<string>();

    // Output: a, az, aza, did, difid, dir, madam, madamk, madk, madkm
    const string test001 = @"6
a##km#
z#ada#
a*m###
#d####
rifid#
#d#d#t
";

    public static void Main()
    {
        ////// This is bad practice, use a 'using' construct with StreamReader!
        ////Console.SetIn(new StreamReader("../../Tests/test_001.txt"));

        // This is bad practice, use a 'using' construct with StringReader!
        Console.SetIn(new StringReader(test001));

        rows = int.Parse(Console.ReadLine());
        matrix = new string[rows];
        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine();
        }

        cols = matrix[0].Length;
        visited = new bool[rows, cols];

        var startCell = FindStartCell();
        DFS(startCell);

        AllWords.Sort();
        Console.WriteLine(string.Join(", ", AllWords));
    }

    private static Cell FindStartCell()
    {
        int row, col;
        row = col = 0;
        for (row = 0; row < rows; row++)
        {
            col = matrix[row].IndexOf(StartCell);
            if (col > -1)
            {
                break;
            }
        }

        return new Cell(row, col, 0);
    }

    private static void DFS(Cell cell)
    {
        var isExit = false;
        for (int i = 0; i < 4; i++)
        {
            var nextCell = new Cell(cell.Row + dRow[i], cell.Col + dCol[i], cell.Dist + 1);

            if (!IsInside(nextCell))
            {
                // Exit
                if (!isExit)
                {
                    isExit = true;
                    AllWords.Add(WordBuffer.ToString());
                }

                continue;
            }

            if (IsPassable(nextCell) && !IsVisited(nextCell))
            {
                visited[cell.Row, cell.Col] = true;
                WordBuffer.Append(matrix[nextCell.Row][nextCell.Col]);
                DFS(nextCell);
                WordBuffer.Length--;
                visited[cell.Row, cell.Col] = false;
            }
        }
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
        return char.IsLetter(matrix[cell.Row][cell.Col]);
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
