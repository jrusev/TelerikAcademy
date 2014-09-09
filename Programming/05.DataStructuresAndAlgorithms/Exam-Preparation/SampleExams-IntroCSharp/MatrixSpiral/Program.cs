using System;

public class MatrixSpiral
{
    private static int[] dRow = { 1, 0, -1, 0 };
    private static int[] dCol = { 0, -1, 0, 1 };

    internal static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        FillMatrix(matrix, n);
        PrintMatrix(matrix, n);
    }

    private static void FillMatrix(int[,] matrix, int n)
    {
        int row = n % 2 == 0 ? (n / 2) - 1 : (n / 2);
        int col = n / 2;
        int direction = 3; // 'right', so the next direction is 'down'

        for (int i = 0; i < n * n; i++)
        {
            // Add '1' so that the center cell is not '0' like the unvisited cells
            matrix[row, col] = i + 1;            
            
            // While the cell in the next direction is already visited...
            int nextDirection = (direction + 1) % 4;
            while (matrix[row + dRow[nextDirection], col + dCol[nextDirection]] > 0 && i < (n * n - 1))
            {
                // ... continue in the same direction
                row += dRow[direction];
                col += dCol[direction];
                matrix[row, col] = ++i + 1;
            }

            // We can now go in the new direction
            direction = (direction + 1) % 4;
            row += dRow[direction];
            col += dCol[direction];
        }
    }

    private static void PrintMatrix(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}", matrix[i, j] - 1);
            }

            Console.WriteLine();
        }
    }
}