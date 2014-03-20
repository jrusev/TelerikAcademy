using System;

class SumFibonacci
{
    static void Main()
    {
        // Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci:
        // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());

        if (n<=2) // special case where n=1 or n=2, the sum is 0 or 1
        {
            Console.WriteLine("The sum is {0}.",n-1);
        }
        else // n>2
        {
            decimal[] fiboSequence = new decimal[n]; // we will store the fibo numbers in an array with N elements
            fiboSequence[0] = 0;
            fiboSequence[1] = 1;
            decimal fiboSum = 1; // 1 is the sum of the first two members; decimal can hold a very big value
            for (int i = 2; i < n; i++) // we start from the 3rd member of the sequence, this allows us to sum the previous two elements
            {
                fiboSequence[i] = fiboSequence[i - 2] + fiboSequence[i - 1];
                fiboSum += fiboSequence[i];
            }
            Console.WriteLine("The sum of the first {0} members of the sequence of Fibonacci is {1}.", n, fiboSum);
        }
    }
}
