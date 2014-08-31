using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that extracts from a given sequence of strings all elements that present in it odd number of times.
// Example: {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}
public class Program
{
    public static void Main()
    {
        var sequence = new[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        Console.WriteLine("[{0}]", string.Join(", ", sequence));

        var occurances = FindOccurances(sequence);
        var oddOccuringItems = occurances.Where(p => p.Value % 2 != 0).Select(p => p.Key);

        Console.WriteLine("Occuring odd number of times: [{0}]", string.Join(", ", oddOccuringItems));
    }

    // Finds the number of occurances of each item in a collection.
    public static IDictionary<T, int> FindOccurances<T>(IEnumerable<T> collection)
    {
        var dict = new Dictionary<T, int>();
        foreach (var item in collection)
        {
            dict[item] = dict.ContainsKey(item) ? dict[item] + 1 : 1;
        }

        return dict;
    }
}
