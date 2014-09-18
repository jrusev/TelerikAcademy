using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static bool[,] matrix;
    static HashSet<string> used = new HashSet<string>();
    const string Test001 = @"18
11 20
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 1 1 1 1 1 1 1 1 1 1 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
";

    static void Main()
    {
        //Console.SetIn(new StringReader(Test001));
        int n = int.Parse(Console.ReadLine());
        var sizes = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int rows = sizes[0];
        int cols = sizes[1];

        matrix = new bool[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var cells = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = cells[col] == 1 ? true : false;
            };
        }

        PlayGame(n);
    }

    private static void PlayGame(int n)
    {
        for (int i = 0; i < n; i++)
        {
            string hash = StringifyMatrix(matrix);
            if (used.Contains(hash))
            {
                continue;
            }

            //PrintTable(matrix);
            //Console.ReadKey(true);
            //Console.Clear();

            UpdateCells();
        }

        //PrintTable(matrix);
        Console.WriteLine(CountAllLiveCells(matrix));
    }

    private static string StringifyMatrix(bool[,] d)
    {
        var sb = new StringBuilder();
        for (int row = 0; row < d.GetLength(0); row++)
        {
            for (int col = 0; col < d.GetLength(1); col++)
            {
                sb.Append(d[row, col] ? '1' : '0');
            }
        }

        return sb.ToString();
    }

    private static void UpdateCells()
    {
        var newMatrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        for (int row = 0; row < matrix.GetLength(0); row++)
            for (int col = 0; col < matrix.GetLength(1); col++)
                newMatrix[row, col] = IsCellAlive(row, col);

        matrix = newMatrix;
    }

    private static bool IsCellAlive(int row, int col)
    {
        int liveNeighbors = CountLiveNeighbors(row, col);

        if (!matrix[row, col] && liveNeighbors == 3)
            return true;  // Размножаване (раждане)
        else if (!matrix[row, col] && liveNeighbors != 3)
            return false; // Пустеене
        else if (matrix[row, col] && (liveNeighbors == 2 || liveNeighbors == 3))
            return true;  // Оцеляване
        else if (matrix[row, col] && liveNeighbors < 2)
            return false; // Смърт от изолация
        else
            return false; // Смърт от пренаселване
    }

    private static int CountLiveNeighbors(int row, int col)
    {
        int liveCount = 0;
        for (int drow = -1; drow <= 1; drow++)
            for (int dcol = -1; dcol <= 1; dcol++)
                if (!(drow == 0 && dcol == 0) && IsInside(row + drow, col + dcol) && matrix[row + drow, col + dcol])
                    liveCount++;
        return liveCount;
    }

    private static bool IsInside(int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }

    private static int CountAllLiveCells(bool[,] matrix)
    {
        int liveCells = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
            for (int col = 0; col < matrix.GetLength(1); col++)
                if (matrix[row, col])
                    liveCells++;

        return liveCells;
    }

    private static void PrintTable(bool[,] d)
    {
        for (int row = 0; row < d.GetLength(0); row++)
        {
            for (int col = 0; col < d.GetLength(1); col++)
            {
                Console.Write("{0,2}", d[row, col] ? '1' : ' ');
            }
            Console.WriteLine();
        }
    }
}

