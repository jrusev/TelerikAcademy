using System;

class CheckNeighbors
{
    static void Main()
    {
        // Write a method that checks if the element at given position in given array of integers
        // is bigger than its two neighbors (when such exist).

        int[] numbers = { 2, 3, 5, 5, 6, 6, 7, 4, 3, 5, 8, 9, 4, 7, 4, 6, 3 };

        // Print the indexes
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Index:");
        for (int i = 0; i < numbers.Length; i++) Console.Write("{0,3}", i);
        Console.ResetColor();
        Console.WriteLine();

        // Print the array
        Console.Write("Array:");
        for (int i = 0; i < numbers.Length; i++) Console.Write("{0,3}", numbers[i]);
        Console.WriteLine();

        Console.Write("Which element do you want to check (enter the index): ");
        int checkIndex = int.Parse(Console.ReadLine());

        bool isBigger = IsBiggerThanNeighbors(numbers, checkIndex);
        bool isLimit = (checkIndex == 0) || (checkIndex == numbers.Length - 1);
        Console.WriteLine("The element at postion {0} is {1} than its neighbor{2}.", checkIndex, isBigger ? "bigger" : "not bigger", isLimit ? "" : "s");
    }

    static bool IsBiggerThanNeighbors(int[] array, int checkIndex)
    {
        if (array.Length < 2) // empty array or just one element
        {
            return false;
        }
        else if (checkIndex == 0) // first element
        {
            return array[checkIndex] > array[checkIndex + 1];
        }
        else if (checkIndex == array.Length - 1) // last element
        {
            return array[checkIndex] > array[checkIndex - 1];
        }
        else
        {
            return (array[checkIndex] > array[checkIndex + 1]) && (array[checkIndex] > array[checkIndex - 1]);
        }
    }
}
