using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Write a program that counts how many times each word from given text file words.txt appears in it.
// The character casing differences should be ignored.
// The result words should be ordered by their number of occurrences in the text.
// Example: 
// "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?"
//    is -> 2
//    the -> 2
//    this -> 3
//    text -> 6
public class Program
{
    public static void Main()
    {
        using (var input = new StreamReader("../../words.txt"))
        {
            var words = new List<string>();
            var separators = new[] { " ", ".", ",", "!", "?", "-" };

            string fileLine;
            while ((fileLine = input.ReadLine()) != null)
            {                
                var splitted = fileLine.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());
                words.AddRange(splitted);
            }

            var occurances = FindOccurances(words);
            PrintOccurances(occurances); 
        }        
    }

    // Prints a dictionary ordered by values
    private static void PrintOccurances<T>(IDictionary<T, int> dict)
    {
        var ordered = dict.OrderBy(p => p.Value);
        foreach (var pair in ordered)
        {
            Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
        }
    }

    // Finds the number of occurances of each item in a collection.
    private static IDictionary<T, int> FindOccurances<T>(IEnumerable<T> collection)
    {
        var dict = new Dictionary<T, int>();
        foreach (var item in collection)
        {
            int value;
            dict[item] = dict.TryGetValue(item, out value) ? value + 1 : 1;
        }

        return dict;
    }
}
