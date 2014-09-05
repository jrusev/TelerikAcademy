using System;
using System.Linq;

// Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
// Example: n=3, k=2, set = {hi, a, b} => (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
internal class Variations
{
    private static string[] set = new[] { "hi", "a", "b" };

    internal static void Main()
    {
        int n = set.Length;
        int k = 2;

        if (!(0 < k && k <= n))
        {
            throw new InvalidOperationException();
        }

        Variate(0, n, k, new int[k]);
    }

    private static void Variate(int p, int n, int k, int[] variation)
    {
        if (p == k)
        {
            Console.WriteLine("({0})", string.Join(", ", variation.Select(i => set[i])));
            return;
        }

        for (int i = 0; i < n; i++)
        {
            variation[p] = i;
            Variate(p + 1, n, k, variation);
        }
    }
}