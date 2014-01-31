using System;

class CatalanNumbers
{
    static void Main()
    {
        // Write a program to calculate the Nth Catalan number by given N.
        // http://en.wikipedia.org/wiki/Catalan_number
        // The first Catalan numbers for n = 0, 1, 2, 3, … are
        // 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, ...

        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        decimal catalan = 1;
        for (int k = 2; k <= n; k++)
        {
            catalan = catalan * (n + k) / k;
        }
        Console.WriteLine("The {0}th Catalan number is {1:F0}.",n,catalan);
    }
}
