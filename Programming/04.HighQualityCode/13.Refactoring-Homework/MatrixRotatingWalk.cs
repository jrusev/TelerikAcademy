using System;

internal class MatrixRotatingWalk
{
    private static int[,] matrix;
    private static int[] dRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
    private static int[] dCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

    private static void Main()
    {
        int n = 6; //  GetMatrixSizeFromInput();
        matrix = new int[n, n];
        int counter = 0;
        int currDir = 0;
        int currRow;
        int currCol;

        while (TryGetEmptyCell(out currRow, out currCol))
        {
            matrix[currRow, currCol] = ++counter;

            while (IsNextToEmptyCell(currRow, currCol))
            {
                while (CanGoInThisDirection(currRow, currCol, currDir))
                {
                    currRow += dRow[currDir];
                    currCol += dCol[currDir];
                    matrix[currRow, currCol] = ++counter;
                }

                // Rotate clockwise
                currDir = (currDir == 7) ? 0 : currDir + 1;
            }
        }

        PrintMatrix();
    }

    private static bool CanGoInThisDirection(int currRow, int currCol, int currDir)
    {
        int nextRow = currRow + dRow[currDir];
        int nextCol = currCol + dCol[currDir];
        var result =
            IsInsideMatrix(nextRow, nextCol) &&
            matrix[nextRow, nextCol] == 0;
        return result;
    }

    private static bool IsInsideMatrix(int row, int col)
    {
        var isInside =
            row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        return isInside;
    }

    private static bool IsNextToEmptyCell(int currRow, int currCol)
    {
        int row, col;
        for (int i = 0; i < 8; i++)
        {
            row = currRow + dRow[i];
            col = currCol + dCol[i];
            if (IsInsideMatrix(row, col) && matrix[row, col] == 0)
            {
                return true;
            }
        }

        return false;
    }

    private static bool TryGetEmptyCell(out int currRow, out int currCol)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 0)
                {
                    currRow = row;
                    currCol = col;
                    return true;
                }
            }
        }

        currRow = currCol = 0;
        return false;
    }

    private static void PrintMatrix()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,3}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static int GetMatrixSizeFromInput()
    {
        Console.Write("Enter the size of the matrix (between 1 and 100): ");
        string input = Console.ReadLine();
        int n = 0;
        while (!int.TryParse(input, out n) || n < 0 || n > 100)
        {
            Console.WriteLine("You haven't entered a correct positive number");
            input = Console.ReadLine();
        }

        return n;
    }
}
