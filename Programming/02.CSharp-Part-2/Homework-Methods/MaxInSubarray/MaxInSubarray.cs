using System;

class MaxInSubarray
{
    static void Main()
    {
        // Write a method that returns the maximal element in a portion of array of integers starting at given index.
        // Using it write another method that sorts an array in ascending / descending order.

        int[] numbers = { 17, 4, 7, 18, 2, 9, 3, 15, 19, 42, 0, 25, 18, 6, 11, 7, 8 };
        Console.WriteLine("Array: " + String.Join(", ", numbers)); // Print the array

        Console.Write("Where do you want to search from (enter index): ");
        int startIndex = int.Parse(Console.ReadLine());

        int indexMax = IndexOfMaxInSubarray(startIndex, numbers);
        Console.WriteLine("The max element is {0}.", numbers[indexMax]);

        Console.Write("\nSort in ascending (press 'A') or descending order (press 'D')?");
        bool choice = (Console.ReadKey(true).Key == ConsoleKey.A);

        SelectionSort(choice, numbers);
        Console.Write("\nSorted: " + String.Join(", ", numbers) + "\n");
    }

    /// <summary>Finds the maximal element in a portion of array of integers starting at given index.</summary>
    static int IndexOfMaxInSubarray(int start, int end, params int[] array)
    {
        // Normalize start and end
        if (start > end) // Swap
        {
            int temp = start;
            start = end;
            end = temp;
        }
        if (start < 0) start = 0;
        if (end > array.Length - 1) end = array.Length - 1;

        int maxElement = array[start];
        int maxIndex = start;

        for (; start <= end; start++)
        {
            if (array[start] > maxElement)
            {
                maxElement = array[start];
                maxIndex = start;
            }
        }
        return maxIndex;
    }

    static int IndexOfMaxInSubarray(int start, params int[] array)
    {
        // An overload to enable searching by start index
        return IndexOfMaxInSubarray(start, array.Length - 1, array);
    }

    static void SelectionSort(bool ascending, params int[] array)
    {
        // Works like selection sort; uses IndexOfMaxInSubarray
        int start = 0;
        int end = array.Length - 1;

        while (start < array.Length && end >= 0)
        {
            int indexMax = IndexOfMaxInSubarray(start, end, array);

            // Swaps from the left or from the right
            int temp = array[indexMax];
            array[indexMax] = array[ascending ? end : start];
            array[ascending ? end : start] = temp;

            if (ascending) end--;
            else start++;
        }
    }

    static void SelectionSort(params int[] array)
    {
        // An overload to enable sorting in ascending order by default 
        SelectionSort(true, array);
    }
}