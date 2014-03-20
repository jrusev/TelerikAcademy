using System;

class CalculateSumFromString
{
    static void Main()
    {
        // You are given a sequence of positive integer values written into a string, separated by spaces.
        // Write a function that reads these values from given string and calculates their sum.
        // Example: string = "43 68 9 23 318" -> result = 461

        string sequence = "   43 68 9 23     318 "; // with some extra white space between the numbers

        // Make an array of all substrings in the sequence that are delimited by a single space ' '.        
        char[] separators = { ' ' };
        string[] numbers = sequence.Split(separators, StringSplitOptions.RemoveEmptyEntries); // Omit empty strings

        // Print the cleaned-up array of numbers, separated by space
        Console.WriteLine(String.Join(" ", numbers)); // "43 68 9 23 318"

        // Calculate the sum
        int sum = 0;
        foreach (var num in numbers)
        {
            sum += int.Parse(num);
        }

        Console.WriteLine("Sum = {0}", sum);
    }
}