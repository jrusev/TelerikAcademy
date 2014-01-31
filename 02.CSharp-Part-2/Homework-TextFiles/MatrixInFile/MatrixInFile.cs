using System;
using System.IO;

class MatrixInFile
{
    static void Main()
    {
        /* Write a program that reads a text file containing a square matrix of numbers
         * and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
         * The first line in the input file contains the size of matrix N.
         * Each of the next N lines contain N numbers separated by space.
         * The output should be a single number in a separate text file.
         * Example:
            4
            2 3 3 4
            0 2 3 4		->	17
            3 7 1 2
            4 3 3 2
         */

        int[,] matrix = ParseMatrix(@"...\...\Matrix.txt");
        int bestSum = FindMaximalSum(matrix);
        Console.WriteLine("Maximal sum of 2x2 block: " + bestSum);
    }

    // Reads the file and fills a square array of numbers
    static int[,] ParseMatrix(string path)
    {
        using (StreamReader input = new StreamReader(path))
        {
            int n = int.Parse(input.ReadLine());

            int[,] matrix = new int[n, n]; // square matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string matrixRow = input.ReadLine();

                // Make an array of all substrings in the matrixRow that are delimited by a single space ' '.        
                char[] separators = { ' ' };
                string[] numbers = matrixRow.Split(separators, StringSplitOptions.RemoveEmptyEntries); // Omit empty strings

                // Print the numbers in the row, separated by spaces
                Console.WriteLine(String.Join(" ", numbers));

                // Parse each number in the row and put it in the matrix of numbers
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);
                }
            }

            return matrix;
        }
    }

    // Finds the maximum sum in an array
    static int FindMaximalSum(int[,] matrix)
    {
        int bestSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int sum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                if (sum >= bestSum)
                {
                    bestSum = sum;
                }
            }
        }
        return bestSum;
    }
}