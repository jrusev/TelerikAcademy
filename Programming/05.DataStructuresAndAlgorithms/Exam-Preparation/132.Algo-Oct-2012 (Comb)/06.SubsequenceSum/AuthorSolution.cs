using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }

    static void Solve()
    {
        var input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        var set = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        Console.WriteLine(CalculateBinom(n - 1, k) * set.Sum());
    }

    public static long CalculateBinom(int n, int k)
    {
        long nominator = 1;
        for (int i = n; i >= (n - k + 1); i--)
            nominator *= i;

        long denominator = 1;
        for (int i = k; i >= 1; i--)
            denominator *= i;

        return (nominator / denominator);
    }
}
