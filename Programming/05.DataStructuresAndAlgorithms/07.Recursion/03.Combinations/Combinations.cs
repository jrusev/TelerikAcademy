using System;

// Modify the previous program to skip duplicates:
// n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
internal class Combinations
{
    internal static void Main()
    {
        int n = 4;
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

        int num = (p == 0) ? 1 : arr[p - 1] + 1;
        for (; num <= n; num++)
        {
            arr[p] = num;
            Combinate(p + 1, n, k, arr);
        }
    }
}
