using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var args = Console.ReadLine();
        var var1 = args[1];
        var var2 = args[3];

        string empty = Console.ReadLine(); // some bug in the input
        int n = int.Parse(Console.ReadLine());

        var coeff = new List<long>() { 1 };
        for (int k = 0; k < n; k++)
            coeff.Add(coeff[k] * (n - k) / (k + 1));

        var terms = new List<string>() { "(" + var1 + "^" + n + ")" };
        for (int i = 1; i < n; i++)
        {
            terms.Add(coeff[i] + "(" + var1 + "^" + (n - i) + ")(" + var2 + "^" + i + ")");
        }
        terms.Add("(" + var2 + '^' + n + ')');

        Console.WriteLine(string.Join("+", terms));
    }
}