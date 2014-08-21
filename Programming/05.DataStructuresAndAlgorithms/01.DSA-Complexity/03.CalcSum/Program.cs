using System;

internal class Program
{
    // What is the expected running time of the following C# code? Explain why.
    private static long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            sum += matrix[row, col];
            count++;
        }
            
        if (row + 1 < matrix.GetLength(0))
            sum += CalcSum(matrix, row + 1);
        return sum;
    }

    // Count how many times the operation runs.
    static int count;

    // ANSWER: 
    // The running time is O(n*m).
    // The first sum cycle is called recursively 'm' times,
    // and the sum operation is executed 'n' times, so a total of n*m.
    private static void Main()
    {
        count = 0;
        int n = 1000, m = 1000;
        int[,] matrix = new int[n, m];
        long sum = CalcSum(matrix, 0);
        Console.WriteLine("{0:n0}", count);
    }
}