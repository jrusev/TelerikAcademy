using System;

// Write a recursive program for generating and printing all permutations
// of the numbers 1, 2, ..., n for given integer number n.
// Example: n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}
internal class Permutations
{
    internal static void Main()
    {
        int n = 3;
        Permutate(0, n, new int[n], new bool[n]);
    }

    private static void Permutate(int p, int n, int[] arr, bool[] used)
    {
        if (p == n)
        {
            Console.WriteLine("{{{0}}}", string.Join(", ", arr));
            return;
        }

        for (int num = 0; num < n; num++)
        {
            if (used[num])
            {
                continue;
            }

            arr[p] = num + 1;
            used[num] = true;
            Permutate(p + 1, n, arr, used);
            used[num] = false;
        }
    }
}
