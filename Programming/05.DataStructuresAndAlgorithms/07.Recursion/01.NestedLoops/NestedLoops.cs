using System;

// Write a recursive program that simulates the execution of n nested loops from 1 to n. 
internal class NestedLoops
{
    internal static void Main()
    {
        int n = 3;
        NestLoops(0, n, new int[n]);
    }

    private static void NestLoops(int i, int n, int[] arr)
    {
        if (i == n)
        {
            Console.WriteLine(string.Join(", ", arr));
            return;
        }

        for (int num = 1; num <= n; num++)
        {
            arr[i] = num;
            NestLoops(i + 1, n, arr);
        }
    }
}