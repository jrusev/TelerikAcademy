using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CountWordsInText
{
    static void Main()
    {
        // Write a program that reads a string and lists all different words in the string along with information how many times each word is found.

        string str = "Read a string and list all different words in the string, and how many times each word is found (in the string).";
        Console.WriteLine(str);

        char[] separators = { ' ', ',', '.', ';', '!', '?', '\n', '\t', '\r', '[', ']', '{', '}', '(',')' };
        string[] words = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> dict = new Dictionary<string, int>();

        // Fill the dictionary
        foreach (var word in words)
        {
            dict[word] = dict.ContainsKey(word) ? dict[word] + 1 : 1;
        }

        // Order the dictionary by value using LINQ
        var ordered = dict.OrderBy(x => -x.Value);

        // Loop through the <key,value> pairs
        Console.WriteLine("\n{0,-10}: {1}", "Word", "Count");
        foreach (var pair in ordered)
        {
            Console.WriteLine("{0,-10}: {1}", pair.Key, pair.Value);
        }
    }
}