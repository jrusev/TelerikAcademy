using System;

class SquareMatrix
{
    static void Main()
    {
        // Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
        // For N = 4:
        //  1 2 3 4
        //  2 3 4 5
        //  3 4 5 6
        //  4 5 6 7

        Console.Write("Please enter N (N<20): ");
        int n;
        while (true)
        {
            n = int.Parse(Console.ReadLine());
            if (n > 0 && n < 20) { break; }
            Console.Write("Please enter N (N<20): ");
        }
        for (int row = 1; row <= n; row++)
        {
            for (int col = row; col < row + n; col++)
            {
                Console.Write("{0,3}", col);
            }
            Console.WriteLine();
        }
    }
}
