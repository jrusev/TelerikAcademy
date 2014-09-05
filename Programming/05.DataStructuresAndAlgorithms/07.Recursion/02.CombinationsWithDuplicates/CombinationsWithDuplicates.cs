using System;

internal class CombinationsWithDuplicates
{
    // Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set.
    // Example: n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
    internal static void Main()
    {
        int n = 3;
        int k = 2;

        if (!(0 < k && k <= n))
        {
            throw new InvalidOperationException();
        }

        Combinate(0, n, k, new int[k]);
    }

    private static void Combinate(int p, int n, int k, int[] arr)
    {
        if (p == k)
        {
            Console.WriteLine("({0})", string.Join(" ", arr));
            return;
        }

        int num = (p == 0) ? 1 : arr[p - 1];
        for (; num <= n; num++)
        {
            arr[p] = num;
            Combinate(p + 1, n, k, arr);
        }
    }
}
