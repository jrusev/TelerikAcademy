using System;

internal class MatrixRotatingWalk
{
    private static int[,] matrix;
    private static int currRow;
    private static int currCol;
    private static int currentDirection;
    private static int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
    private static int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

    private static void Main()
    {
        int n = 6; //  GetMatrixSizeFromInput();
        matrix = new int[n, n];
        int counter = 0;
        currRow = 0;
        currCol = 0;
        currentDirection = 0;

        while (EmptyCellAvailable())
        {
            matrix[currRow, currCol] = ++counter;

            while (IsNextToEmptyCell())
            {
                while (CanGoInThisDirection())
                {
                    currRow += dirX[currentDirection];
                    currCol += dirY[currentDirection];
                    matrix[currRow, currCol] = ++counter;
                }

                RotateClockwise();
            }
        }

        PrintMatrix();
    }

    private static bool CanGoInThisDirection()
    {
        int nextX = currRow + dirX[currentDirection];
        int nextY = currCol + dirY[currentDirection];
        var result =
            IsInsideMatrix(nextX, nextY) &&
            matrix[nextX, nextY] == 0;
        return result;
    }

    private static bool IsInsideMatrix(int row, int col)
    {
        var isInside =
            row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        return isInside;
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

    private static void RotateClockwise()
    {
        currentDirection = (currentDirection == 7) ? 0 : currentDirection + 1;
    }

    private static bool IsNextToEmptyCell()
    {
        int row, col;
        for (int i = 0; i < 8; i++)
        {
            row = currRow + dirX[i];
            col = currCol + dirY[i];
            if (IsInsideMatrix(row, col) && matrix[row, col] == 0)
            {
                return true;
            }
        }

        return false;
    }

    private static bool EmptyCellAvailable()
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

        return false;
    }
}
