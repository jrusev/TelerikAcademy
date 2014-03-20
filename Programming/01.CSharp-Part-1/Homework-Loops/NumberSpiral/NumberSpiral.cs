using System;

class NumberSpiral
{
    static void Main()
    {
        /* Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
        Example for N = 4
        1   2   3   4
        12  13  14  5
        11  16  15  6
        10  9   8   7        
        */

        Console.Write("Please enter an integer between 1 and 20: ");
        int matrixSize = Int32.Parse(Console.ReadLine());
        int[,] spiralMatrix = new int[matrixSize, matrixSize];

        int num = 1; // this is the number we are filling into the array
        int maxNum = matrixSize * matrixSize; // this is the last number in the spiral

        int currentRow = 0;
        int currentCol = 0;

        // (leftCol, rightCol, topRow, bottomRow) define the sides of the square we are currently filling
        // we start from the outside, fill the sides as the spiral goes, and then move the sides towards the center 
        int leftCol = 0;
        int rightCol = matrixSize - 1;
        int topRow = 0;
        int bottomRow = matrixSize - 1;

        while (num <= maxNum) // 'num' can reach maxNum even inside the cycle, but the for() conditions make sure there is no space to fill
        {
            for (currentCol = leftCol; currentCol <= rightCol; currentCol++) // fill right
            {
                spiralMatrix[currentRow, currentCol] = num;
                num++;
            }
            currentCol--;

            for (currentRow++; currentRow <= bottomRow; currentRow++) // fill down
            {
                spiralMatrix[currentRow, currentCol] = num;
                num++;
            }
            currentRow--;

            for (currentCol--; currentCol >= leftCol; currentCol--) // fill left
            {
                spiralMatrix[currentRow, currentCol] = num;
                num++;
            }
            currentCol++;

            for (currentRow--; currentRow > topRow; currentRow--) // fill up
            {
                spiralMatrix[currentRow, currentCol] = num;
                num++;
            }
            currentRow++;

            // move the sides towards the center
            leftCol++;
            rightCol--;
            topRow++;
            bottomRow--;
        }

        // print the array
        Console.WriteLine();
        for (int arrayRow = 0; arrayRow < matrixSize; arrayRow++)
        {
            for (int arrayCol = 0; arrayCol < matrixSize; arrayCol++)
            {
                Console.Write("{0,4}", spiralMatrix[arrayRow, arrayCol]);
            }
            Console.WriteLine("\n");
        }
    }
}

