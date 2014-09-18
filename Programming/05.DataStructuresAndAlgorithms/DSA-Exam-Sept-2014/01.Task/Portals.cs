using System;

class Portals
{
    static int[] dRow = new int[] {  0, 1, 0, -1 };
    static int[] dCol = new int[] { -1, 0, 1,  0 };

    static int[,] matrix;
    static int rows;
    static int cols;

    static void Main()
    {
        var xy = Console.ReadLine().Split(' ');
        int startRow = int.Parse(xy[0]);
        int startCol = int.Parse(xy[1]);

        var rc = Console.ReadLine().Split(' ');
        rows = int.Parse(rc[0]);
        cols = int.Parse(rc[1]);

        matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            var splitted = Console.ReadLine().Split(
                new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < cols; col++)
            {
                if (splitted[col] == "#")
                    matrix[row, col] = -1;
                else
                    matrix[row, col] = int.Parse(splitted[col]);
            }
        }

        Console.WriteLine(DFS(startRow, startCol));
    }

    private static int DFS(int startRow, int startCol)
    {
        int power = matrix[startRow, startCol];

        if (power == 0)
            return 0;

        int maxSum = 0;
        for (int i = 0; i < 4; i++)
        {
            int row = startRow + power * dRow[i];
            int col = startCol + power * dCol[i];

            if (IsInsideMatrix(row, col) && matrix[row, col] != -1)
            {
                matrix[startRow, startCol] = 0; // deactivate the teleport
                maxSum = Math.Max(maxSum, DFS(row, col));
            }
        }        

        // If teleport was used - add its power, else return 0;
        maxSum = (matrix[startRow, startCol] == 0) ? maxSum + power : 0;

        matrix[startRow, startCol] = power; // re-activate the teleport

        return maxSum;
    }

    private static bool IsInsideMatrix(int row, int col)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }
}