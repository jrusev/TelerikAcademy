using System;

class MaxSumSquare
{
    static void Main()
    {
        // Write a program that reads a rectangular matrix of size N x M
        // and finds in it the square 3 x 3 that has maximal sum of its elements.

        int[,] matrix = RandomMatrix();

        int maxSum = int.MinValue;
        int squareX = 0; // upper-left corner of the square
        int squareY = 0; // upper-left corner of the square
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int sum = 0;
                for (int squareRow = 0; squareRow < 3; squareRow++)
                {
                    for (int squareCol = 0; squareCol < 3; squareCol++)
                    {
                        sum += matrix[row + squareRow, col + squareCol];
                    }
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    squareX = row;
                    squareY = col;
                }
            }   
        }
        PrintRed(matrix, squareX, squareY); // prints the matrix and marks the square in red

        // print only the square with maximal sum
        Console.WriteLine("Square 3 x 3 that has maximal sum of its elements:");
        int[,] square = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                square[i, j] = matrix[squareX + i, squareY + j];
            }
        }
        Print(square);
    }

    static int[,] RandomMatrix()
    {
        Random rand = new Random();
        int rows = rand.Next(3, 20); // [3;20)
        int cols = rand.Next(3, 20); // [3;20)
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rand.Next(100); // [0;100)
            }
        }
        return matrix;
    }

    static void Print(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(Convert.ToString(matrix[row, col]).PadRight(3, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void PrintRed(int[,] matrix, int squareX, int squareY )
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (row >= squareX && row <= squareX + 2 && col >= squareY && col <= squareY + 2)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Convert.ToString(matrix[row, col]).PadRight(3, ' '));
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}