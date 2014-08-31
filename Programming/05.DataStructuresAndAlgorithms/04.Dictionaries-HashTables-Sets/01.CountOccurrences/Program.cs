using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that counts in a given array of double values the number of occurrences of each value.
// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
//  -2.5 -> 2 times
//  3 -> 4 times
//  4 -> 3 times
public class Program
{
    public static void Main()
    {
        double[] array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
        Console.WriteLine("[{0}]", string.Join(", ", array));

        var dict = new SortedDictionary<double, int>();
        foreach (var num in array)
        {
            dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;
        }

        foreach (var pair in dict)
        {
            Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
        } 
       
        // Second approach: group the repeating elements
        var occurances = array.GroupBy(el => el).ToDictionary(gr => gr.Key, gr => gr.Count());
        //// Console.WriteLine(string.Join(", ", occurances));
    }
}
