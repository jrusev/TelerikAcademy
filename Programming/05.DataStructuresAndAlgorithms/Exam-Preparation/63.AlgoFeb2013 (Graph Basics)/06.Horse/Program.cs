using System;
using System.Collections.Generic;

class Program
{
    static char[][] matrix;
    static bool[,] used;
    static int startRow;
    static int startCol;
    static int[] dRow = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
    static int[] dCol = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };
    const string Test001 = @"4
- s e -
x - x -
x x - -
- x - x
";
    static void Main(string[] args)
    {
        //Console.SetIn(new StringReader(Test001));

        int n = int.Parse(Console.ReadLine());
        matrix = new char[n][];
        used = new bool[n, n];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine().Replace(" ", "").ToCharArray();
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 's')
                {
                    startRow = i;
                    startCol = j;
                }
            }
        }

        var queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(Tuple.Create(startRow, startCol, 0));
        matrix[startRow][startCol] = 'x';
        used[startRow, startCol] = true;
        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();
            //Console.WriteLine(cell);
            if (matrix[cell.Item1][cell.Item2] == 'e')
            {
                Console.WriteLine(cell.Item3);
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                int row = cell.Item1 + dRow[i];
                int col = cell.Item2 + dCol[i];
                if (row >= 0 && row < n && col >= 0 && col < n && !used[row, col] && matrix[row][col] != 'x')
                {
                    queue.Enqueue(Tuple.Create(row, col, cell.Item3 + 1));
                    used[row, col] = true;
                }
            }
        }

        Console.WriteLine(-1);
    }
}
