using System;

class PrintMatrix
{
    static void Main()
    {
        /* Write a program that fills and prints a matrix of size (n, n) as shown below:
         *        a)                  b)                  c)                  d)
            1	5	9	13		1	8	9	16		7	11	14	16		1	12	11	10
            2	6	10	14		2	7	10	15		4	8	12	15		2	13	16	9
            3	7	11	15		3	6	11	14		2	5	9	13		3	14	15	8
            4	8	12	16		4	5	12	13		1	3	6	10		4	5	6	7
         */

        Console.Write("Size of matrix = ");
        int n = int.Parse(Console.ReadLine());
        //int n = 4;

        PrintMatrixA(n);
        PrintMatrixB(n);
        PrintMatrixC(n);
        PrintMatrixD(n);
    }

    static void PrintMatrixA(int n)
    {
        int[,] matrix = new int[n, n];
        int num = 1;
        for (int col = 0; col < n; col++)
            for (int row = 0; row < n; row++)
                matrix[row, col] = num++;
        Console.WriteLine("A.");
        Print(matrix);
    }

    static void PrintMatrixB(int n)
    {
        int[,] matrix = new int[n, n];
        int num = 1;
        for (int col = 0; col < n; col++)
        {
            int row;
            if (col % 2 == 0)
            {
                for (row = 0; row < n; row++)
                    matrix[row, col] = num++;
            }
            else
            {
                for (row = n - 1; row >= 0; row--)
                    matrix[row, col] = num++;
            }
        }
        Console.WriteLine("B.");
        Print(matrix);
    }

    static void PrintMatrixC(int n)
    {
        int[,] matrix = new int[n, n];
        int num = 1;
        int startRow = n - 1;
        int startCol = 0;
        int cRow = startRow;
        int cCol = startCol;
        while (num <= (n * n))
        {
            matrix[cRow, cCol] = num++;
            if (cRow == n - 1 || cCol == n - 1)
            {
                if (startRow > 0)
                {
                    startRow--;
                    startCol = 0;
                }
                else
                {
                    startCol++;
                }
                cRow = startRow;
                cCol = startCol;
            }
            else
            {
                cRow++;
                cCol++;
            }
        }
        Console.WriteLine("C.");
        Print(matrix);
    }

    static void PrintMatrixD(int n)
    {
        int[,] matrix = new int[n, n];
        int num = 1;
        int row = -1;
        int col = -1;
        int rowMax = n - 1;
        int colMax = n - 1;
        int rowMin = 0;
        int colMin = 1;
        while (num <= (n * n))
        {
            for (col++,row++; row <= rowMax; row++) // down
            {
                matrix[row, col] = num++;
            }
            rowMax--;
            for (row--, col++; col <= colMax; col++) // right
            {
                matrix[row, col] = num++;
            }
            colMax--;
            for (col--, row--; row >= rowMin; row--) // up
            {
                matrix[row, col] = num++;
            }
            rowMin++;
            for (row++,col--; col >= colMin; col--) // left
            {
                matrix[row, col] = num++;
            }
            colMin++;
        }
        Console.WriteLine("D.");
        Print(matrix);
    }

    static void Print(int[,] matrix)
    {
        int offset = matrix.Length.ToString().Length + 1;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(Convert.ToString(matrix[row, col]).PadRight(offset, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}