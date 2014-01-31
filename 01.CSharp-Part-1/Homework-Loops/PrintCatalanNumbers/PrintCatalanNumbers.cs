using System;

class PrintCatalanNumbers
{
    static void Main()
    {
        // Print the first N Catalan numbers
        // The first Catalan numbers for n = 0, 1, 2, 3, … are
        // 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, ...

        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("The first {0} Catalan numbers are:",n);
        for (int i = 0; i < n - 1; i++)
        {
            Console.Write("{0:F0}, ",Catalan(i));
        }
        Console.Write("{0:F0}, ...", Catalan(n-1));
        Console.WriteLine();
    }

    static decimal Catalan(int n)
    {
        decimal catalan = 1;
        for (int k = 2; k <= n; k++)
        {
            catalan = catalan * (n + k) / k;
        }
        return catalan;
    }
}

