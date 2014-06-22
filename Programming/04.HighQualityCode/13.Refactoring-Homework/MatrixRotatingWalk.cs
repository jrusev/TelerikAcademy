using System;

internal class MatrixRotatingWalk
{
    private static int dx;
    private static int dy;
    private static int[,] matrix;
    private static int currRow;
    private static int currCol;

    private static void Main()
    {
        int n = GetMatrixSizeFromInput();
        matrix = new int[n, n];
        int counter = 0;
        currRow = 0;
        currCol = 0;
        dx = 1;
        dy = 1;
        PrintMatrix();

        while (EmptyCellAvailable())
        {
            matrix[currRow, currCol] = ++counter;

            while (IsNextToEmptyCell())
            {
                while (CanGoInThisDirection())
                {                    
                    currRow += dx;
                    currCol += dy;
                    matrix[currRow, currCol] = ++counter;
                } 
  
                RotateClockwise();
            }            
        }

        PrintMatrix();
    }

    private static bool CanGoInThisDirection()
    {
        var result =
            currRow + dx < matrix.GetLength(0) &&
            currRow + dx >= 0 &&
            currCol + dy < matrix.GetLength(1) &&
            currCol + dy >= 0 &&
            matrix[currRow + dx, currCol + dy] == 0;

        return result;
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
        var dirX = new[] { 1, 1, 1, 0, -1, -1, -1, 0 };
        var dirY = new[] { 1, 0, -1, -1, -1, 0, 1, 1 };

        int currentDirectionIndex = 0;
        for (int dir = 0; dir < 8; dir++)
        {
            if (dirX[dir] == dx && dirY[dir] == dy)
            {
                currentDirectionIndex = dir;
                break;
            }
        }

        if (currentDirectionIndex == 7)
        {
            dx = dirX[0];
            dy = dirY[0];
            return;
        }

        dx = dirX[currentDirectionIndex + 1];
        dy = dirY[currentDirectionIndex + 1];
    }

    private static bool IsNextToEmptyCell()
    {
        int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        for (int i = 0; i < 8; i++)
        {
            if (currRow + dirX[i] >= matrix.GetLength(0) || currRow + dirX[i] < 0)
            {
                dirX[i] = 0;
            }                

            if (currCol + dirY[i] >= matrix.GetLength(1) || currCol + dirY[i] < 0)
            {
                dirY[i] = 0;
            }               
        }

        for (int i = 0; i < 8; i++)
        {
            if (matrix[currRow + dirX[i], currCol + dirY[i]] == 0)
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
