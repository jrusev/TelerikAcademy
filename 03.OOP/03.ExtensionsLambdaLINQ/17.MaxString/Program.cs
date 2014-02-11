using System;
using System.Linq;

internal class Program
{
    // Write a program to return the string with maximum length from an array of strings. Use LINQ.
    private static void Main()
    {
        string[] arr = { "dog", "truck", "cuecumber", "door", "garage" };

        // Using query syntax
        Console.WriteLine((from s in arr orderby s.Length select s).Last());

        // Using lambda syntax
        Console.WriteLine(arr.OrderByDescending(s => s.Length).First());

        // Fastest method - O(n) operation
        Console.WriteLine(arr.Aggregate((max, cur) => max.Length > cur.Length ? max : cur));
    }
}