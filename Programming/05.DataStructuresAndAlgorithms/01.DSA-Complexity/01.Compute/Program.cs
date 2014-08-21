using System;

internal class Program
{
    // What is the expected running time of the following C# code? Explain why.
    private static long Compute(int[] arr)
    {
        long count = 0;
        // This loop will run 'n' times.
        for (int i = 0; i < arr.Length; i++)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                // To count how many times the comparison will be performed,
                // we can put the counter here...
                count++;
                if (arr[start] < arr[end])
                {
                    start++;
                    //count++;
                }
                else
                {
                    end--;
                }
            }
        }

        return count;
    }

    // ANSWER:
    // The program will run in O(n^2) time (quadratic time).
    // The outer loop will run 'n' times.
    // The inner loop (while cycle) will run n-1 times,
    // because we will go through all elements.
    // So the comparison will be executed n*(n-1) times, which is O(n^2).
    private static void Main(string[] args)
    {
        int n = 1000;
        int[] arr = new int[n];
        long count = Compute(arr);
        Console.WriteLine("{0:n0}", count);
    }
}