using System;
using System.Collections.Generic;

public class CalcSequenceQueue
{
    // We are given the following sequence:
    //  S1 = N;
    //  S2 = S1 + 1;
    //  S3 = 2*S1 + 1;
    //  S4 = S1 + 2;
    //  S5 = S2 + 1;
    //  S6 = 2*S2 + 1;
    //  S7 = S2 + 2;
    // Using the Queue<T> class write a program to print its first 50 members for given N.
    // Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    private static void Main()
    {
        int n = 2;
        int maxCount = 50;
        var sequence = GetSequence(n, maxCount);
        Console.WriteLine("N={0} -> {1}", n, string.Join(", ", sequence));
    }

    private static List<int> GetSequence(int n, int maxCount)
    {
        var queue = new Queue<int>();
        var sequence = new List<int>();

        queue.Enqueue(n);
        int count = 1;

        while (count <= maxCount)
        {
            int current = queue.Dequeue();
            sequence.Add(current);

            queue.Enqueue(current + 1);
            queue.Enqueue((2 * current) + 1);
            queue.Enqueue(current + 2);

            count += 3;
        }

        while (count > maxCount)
        {
            queue.Dequeue();
            count--;
        }

        sequence.AddRange(queue);
        return sequence;
    }
}