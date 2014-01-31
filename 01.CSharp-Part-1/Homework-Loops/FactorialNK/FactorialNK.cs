using System;

class FactorialNK
{
    static void Main()
    {
        // Write a program that calculates N!/K! for given N and K (1<K<N).

        Console.Write("Please enter integer K: ");
        int k = int.Parse(Console.ReadLine());
        int n;
        while (true)
        {
            Console.Write("Please enter integer N (N>K): ");
            n = int.Parse(Console.ReadLine());
            if (n>k) { break; }
        }
        long factorialNK = 1;
        for (int i = k + 1; i <= n; i++)
        {
            factorialNK = factorialNK * i;
        }
        Console.WriteLine("{0}!/{1}! = {2}",n,k,factorialNK);
    }
}