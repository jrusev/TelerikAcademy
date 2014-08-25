using System;
using System.Collections.Generic;
using System.Linq;

public class CountOccurences
{
    // Write a program that finds in given array of integers (all belonging to the range [0..1000])
    // how many times each of them occurs.
    // Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    // 2 -> 2 times
    // 3 -> 4 times
    // 4 -> 3 times
    private static void Main()
    {
        var nums = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        // We will use that the numbers are in the range [0..1000]
        // to store the occurence of each number in an array,
        // at an index equal to the number.
        var occurences = new int[1001];

        foreach (var num in nums)
        {
            occurences[num]++;
        }

        for (int i = 0; i < occurences.Length; i++)
        {
            if (occurences[i] > 0)
            {
                Console.WriteLine("{0} -> {1} times", i, occurences[i]);
            }
        }
    }
}