using System;
using System.Collections.Generic;
using System.Linq;

internal class SortListAscending
{
    // Write a program that reads a sequence of integers (List<int>) ending with an empty line
    // and sorts them in an increasing order.
    private static void Main()
    {
        Console.WriteLine("Please enter some integers (enter empty line for end):");

        try
        {
            var integers = ReadIntegers();

            if (integers.Count == 0)
            {
                throw new ApplicationException("Cannot sort an empty sequence!");
            }

            integers.Sort();
            Console.WriteLine("Sorted in increasing order: {0}", string.Join(", ", integers));
        }
        catch (ApplicationException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Input was not in the correct format!");
        }
    }

    /// <summary>
    /// Reads integers from the console until an empty line is entered.
    /// </summary>
    private static List<int> ReadIntegers()
    {
        var numbers = new List<int>();
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (input == string.Empty)
            {
                return numbers;
            }

            int num = int.Parse(input);
            numbers.Add(num);
        }
    }
}