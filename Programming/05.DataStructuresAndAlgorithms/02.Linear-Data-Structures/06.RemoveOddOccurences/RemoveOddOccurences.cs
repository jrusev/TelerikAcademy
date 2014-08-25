using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveOddOccurences
{
    // Write a program that removes from given sequence all numbers that occur odd number of times.
    // Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
    private static void Main()
    {
        var nums = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

        // The dictionary will contain each unique number in the sequence as Key,
        // and true/false as Value if that number occurs even/odd number of times.
        var dict = nums.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count() % 2 == 0);

        // Filter the numbers for which the corresponding Value in the dictionary is true,
        // i.e. when they occur even number of times.
        var filtered = nums.Where(x => dict[x]);
        Console.WriteLine(string.Join(", ", filtered));
    }
}