using System;
using System.Collections.Generic;
using System.Linq;

internal class ReverseWithStack
{
    // Write a program that reads N integers from the console and reverses them using a stack.
    // Use the Stack<int> class.
    private static void Main()
    {
        int n = 5;
        Console.WriteLine("Please enter {0} integers:", n);        
        var integers = ReadIntegers(n);

        // The Stack constructor copies the elements
        var stacked = new Stack<int>(integers);

        // This is where the elements are reversed:
        // 1) The Join method iterates over the collection.
        // 2) Because the collection is a stack, the elements are iterated in reverse order.
        Console.WriteLine("Reversed: {0}", string.Join(", ", stacked));
    }

    /// <summary>
    /// Reads 'n' integers from the console.
    /// </summary>
    private static IEnumerable<int> ReadIntegers(int n)
    {
        var integers = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            integers.Add(num);
        }

        return integers;
    }
}