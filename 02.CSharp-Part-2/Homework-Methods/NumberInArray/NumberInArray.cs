using System;

public class NumberInArray
{
    static void Main()
    {
        // Write a method that counts how many times given number appears in given array.
        // Write a test program to check if the method is working correctly.

        int[] numbers = { 2, 3, 5, 5, 6, 6, 7, 4, 3, 5, 8, 9, 4, 7, 4, 6, 3 };
        Console.WriteLine("Array: { "+String.Join(", ", numbers) + " }"); // prints the array

        Console.Write("Which number do you want to search for: ");
        int checkNum = int.Parse(Console.ReadLine());

        int countNum = CountOccurence(numbers, checkNum);
        Console.WriteLine("The number {0} appears {1} time{2}.", checkNum, countNum, countNum == 1 ? "" : "s");
    }

    /// <summary>Counts how many times a given number appears in an array.</summary>
    /// <param name="array">The array to check.</param>
    /// <param name="checkNum">The number to check.</param>
    /// <returns>Returns the number of appearances or 0 if the number is not found in the array.</returns>
    public static int CountOccurence(int[] array, int checkNum)
    {
        int count = 0;
        foreach (var number in array) if (number == checkNum) count++;
        return count;
    }
}
