using System;

internal class EightQueensPuzzle
{
    private const int SIZE = 8;
    private const int OFFSET = 2 * SIZE;
    private static bool[] usedCols = new bool[SIZE];
    private static bool[] usedDiags = new bool[4 * SIZE];
    private static int count = 0;

    internal static void Main()
    {
        Queens(0, new int[SIZE]);
        Console.WriteLine(count);
    }

    private static void Queens(int row, int[] queens)
    {
        for (int col = 0; col < SIZE; col++)
        {
            if (!usedCols[col] && !usedDiags[row - col + SIZE] && !usedDiags[row + col + OFFSET])
            {
                queens[row] = col;
                usedCols[col] = usedDiags[row - col + SIZE] = usedDiags[row + col + OFFSET] = true;
                if (row == SIZE - 1) count++;
                else Queens(row + 1, queens);
                usedCols[col] = usedDiags[row - col + SIZE] = usedDiags[row + col + OFFSET] = false;
            }
        }
    }
}