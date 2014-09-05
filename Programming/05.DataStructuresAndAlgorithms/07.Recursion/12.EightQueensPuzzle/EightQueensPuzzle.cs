using System;
using System.Linq;
using System.Threading;

// Write a recursive program to solve the "8 Queens Puzzle" with backtracking.
internal class EightQueensPuzzle
{
    private const int SIZE = 8;
    private static int[] queens = new int[SIZE];
    private static bool[] usedCols = new bool[SIZE];
    private static bool[] usedDiag1 = new bool[2 * SIZE];
    private static bool[] usedDiag2 = new bool[2 * SIZE];
    private static int count = 0;

    internal static void Main()
    {
        Queens(0);
    }

    private static void Queens(int row)
    {
        for (int col = 0; col < SIZE; col++)
        {
            if (!usedCols[col] && !usedDiag1[row + col] && !usedDiag2[row - col + SIZE])
            {
                queens[row] = col;
                usedCols[col] = usedDiag1[row + col] = usedDiag2[row - col + SIZE] = true;
                if (row == SIZE - 1) PrintResult();
                else Queens(row + 1);
                usedCols[col] = usedDiag1[row + col] = usedDiag2[row - col + SIZE] = false;
            }
        }
    }

    private static void PrintResult()
    {
        Console.Clear();
        for (int row = 0; row < SIZE; row++)
        {
            int queenCol = queens[row];
            for (int col = 0; col < SIZE; col++)
            {
                Console.BackgroundColor = ((row + col) % 2 == 0) ? ConsoleColor.Gray : Console.BackgroundColor;
                Console.ForegroundColor = ((row + col) % 2 == 0) ? ConsoleColor.Black : Console.ForegroundColor;

                Console.Write(col == queenCol ? " Q" : "  ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        // Show queen positions using chess notation
        Console.WriteLine(string.Join(", ", queens.Select(
            (col, row) => (char)(col + 'a') + "" + (SIZE - row))));
        Console.WriteLine(++count);
        Thread.Sleep(100);
    }
}