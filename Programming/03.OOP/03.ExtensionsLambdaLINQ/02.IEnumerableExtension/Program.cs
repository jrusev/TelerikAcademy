using System;
using System.Collections.Generic;

public class Program
{
    // Implement a set of extension methods for IEnumerable<T>
    // that implement the following group functions: sum, product, min, max, average.
    public static void Main()
    {
        // Create a list of numbers
        var numbers = new List<double>() { 1.5, 2, 3, 4, 5 };
        Console.WriteLine("Numbers: {0}", string.Join(", ", numbers));

        // Test the extension methods
        Console.WriteLine("Sum: {0}", numbers.Sum());
        Console.WriteLine("Average: {0}", numbers.Average());
        Console.WriteLine("Product: {0}", numbers.Product());
        Console.WriteLine("Min: {0}", numbers.Min());
        Console.WriteLine("Max: {0}", numbers.Max());
    }
}
