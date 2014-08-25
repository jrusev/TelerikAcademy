using System;
using System.Collections.Generic;
using System.Linq;

public class Majorant
{
    // The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
    // Write a program to find the majorant of given array (if exists).
    // Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3
    private static void Main()
    {
        var arr = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

        Console.WriteLine("Sequence: {0}", string.Join(", ", arr));
        Console.WriteLine("N = {0}", arr.Length);

        // Build a dictionary that contains the frequency of each element
        var frequencyDict = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        foreach (var pair in frequencyDict)
        {
            Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
        }

        try
        {
            // Find the first (and only) element that occurs at least N/2 + 1 times
            var majorant = frequencyDict.First(p => p.Value > arr.Length / 2).Key;
            Console.WriteLine("Majorant: {0}", majorant);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("The sequence has no majorant.");
        }
    }
}