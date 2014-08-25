using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that reads from the console a sequence of positive integer numbers.
// The sequence ends when empty line is entered.
// Calculate and print the sum and average of the elements of the sequence.
// Keep the sequence in List<int>.
internal class SumAndAverage
{
    private static void Main()
    {
        Console.WriteLine("Please enter some positive integer numbers on new lines:");
        Console.WriteLine("(leave an empty line for end)");
        try
        {
            var numbers = ReadPositiveIntegers();
            if (numbers.Count == 0)
            {
                Console.WriteLine("You did not enter any numbers!");
                return;
            }

            Console.WriteLine("Sum of the numbers: {0}", numbers.Sum());
            Console.WriteLine("Average of the numbers: {0}", numbers.Average());
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Numbers must be positive!");
        }   
        catch (FormatException)
        {
            Console.WriteLine("Input was not in the correct format!");
        }
    }

    private static List<int> ReadPositiveIntegers()
    {
        var numbers = new List<int>();
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                return numbers;
            }

            int num = int.Parse(input);
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            numbers.Add(num);
        }
    }
}