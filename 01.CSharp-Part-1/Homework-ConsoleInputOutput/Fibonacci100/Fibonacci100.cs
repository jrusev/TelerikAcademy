using System;

class Fibonacci100
{
    static void Main()
    {
        // Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
        
        Console.Write("First 100 Fibonacci: 0, 1, ");

        decimal fibo1 = 0;
        decimal fibo2 = 1;
        decimal fiboNext;
        for (decimal i = 2; i < 100; i++)
        {
            fiboNext = fibo1 + fibo2;
            fibo1 = fibo2;
            fibo2 = fiboNext;
            Console.Write("{0}, ", fiboNext);
        }
        Console.WriteLine();
    }
}