using System;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        int k = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        var d = new int[k + 1, n + 1];
        for (int col = 0; col <= n; col++)
            d[0, col] = col;

        for (int row = 1; row <= k; row++)
            for (int col = 1; col <= n; col++)
                d[row, col] = d[row - 1, col] + d[row, col - 1];

        Console.WriteLine(d[k, n]);
        //PrintTable(d);
    }

    private static void PrintTable(int[,] d)
    {
        for (int row = 0; row < d.GetLength(0); row++)
        {
            for (int col = 0; col < d.GetLength(1); col++)
            {
                Console.Write("{0, 4}", d[row, col]);
            }
            Console.WriteLine();
        }
    }
}
