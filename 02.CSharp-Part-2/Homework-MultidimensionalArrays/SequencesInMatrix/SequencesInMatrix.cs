using System;

class SequencesInMatrix
{
    /*
     * We are given a matrix of strings of size N x M.
     * Sequences in the matrix we define as sets of several neighbor elements
     * located on the same line, column or diagonal.
     * Write a program that finds the longest sequence of equal strings in the matrix.
    */

    static int bestLen;
    static int bestX; // upper-left corner of the sequence
    static int bestY; // upper-left corner of the sequence
    static int direction; // direction of the sequence

    static void Main()
    {
        string[,] matrix = RandomStringMatrix();
        bestLen = 0;
        bestX = 0; // upper-left corner of the sequence
        bestY = 0; // upper-left corner of the sequence
        int seqRow, seqCol, len;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                // left
                len = 1; seqRow = row; seqCol = col;
                while ((seqRow < matrix.GetLength(0) - 1) && seqCol > 0)
                {
                    seqRow++;
                    seqCol--;
                    if (matrix[seqRow, seqCol] != matrix[row, col]) break;
                    len++;
                }
                if (len > bestLen)
                {
                    bestLen = len;
                    bestX = row;
                    bestY = col;
                    direction = -1;
                }

                // down
                len = 1; seqRow = row; seqCol = col;
                while (seqRow < matrix.GetLength(0) - 1)
                {
                    seqRow++;
                    if (matrix[seqRow, seqCol] != matrix[row, col]) break;
                    len++;
                }
                if (len > bestLen)
                {
                    bestLen = len;
                    bestX = row;
                    bestY = col;
                    direction = 0;
                }

                // right
                len = 1; seqRow = row; seqCol = col;
                while ((seqRow < matrix.GetLength(0) - 1) && (seqCol < matrix.GetLength(1) - 1))
                {
                    seqRow++;
                    seqCol++;
                    if (matrix[seqRow, seqCol] != matrix[row, col]) break;
                    len++;
                }
                if (len > bestLen)
                {
                    bestLen = len;
                    bestX = row;
                    bestY = col;
                    direction = 1;
                }
            }
        }
        Print(matrix);
        Console.WriteLine("Longest sequence has {0} elements at ({1},{2}).", bestLen, bestX, bestY);
    }

    static string[,] RandomStringMatrix()
    {
        Random rand = new Random();
        int rows = rand.Next(3, 20); // [3;20)
        int cols = rand.Next(3, 20); // [3;20)
        string[,] matrix = new string[rows, cols];
        string[] words = { "ha", "hi", "ho", "he" };
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                string randWord = words[rand.Next(words.Length)];
                matrix[row, col] = randWord;
                //char symb = (char)rand.Next('a', 'd');
                //matrix[row, col] = symb.ToString();
            }
        }
        return matrix;
    }

    static void Print(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (row >= bestX && row < (bestX + bestLen) && (col - bestY) == ((row - bestX) * direction))
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(matrix[row, col].PadRight(3, ' '));
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}