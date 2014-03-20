using System;

public class SortArraySelection
{
    static void Main()
    {
        // Write a program to sort an array. Use the "selection sort" algorithm:
        // Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

        int arrayLen = 10;
        int[] array = new int[arrayLen];

        while (true)
        {
            // fill the array with random numbers between 1 and 100
            Random randomGenerator = new Random();
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = randomGenerator.Next(1, 100); // [1;100)
            }
            Console.Write("Unsorted array: ");
            PrintSequence(array, 0, array.Length - 1); // start index and end index of the sequence
            SelectionSort(array);
            Console.Write("Sorted array:   ");
            PrintSequence(array, 0, array.Length - 1); // start index and end index of the sequence
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }

    public static void SelectionSort(int[] arrayToSort)
    {
        for (int indexSorted = 0; indexSorted < arrayToSort.Length; indexSorted++)
        {
            int smallest = arrayToSort[indexSorted];
            int smallestIndex = indexSorted;
            for (int indexUnSorted = indexSorted + 1; indexUnSorted < arrayToSort.Length; indexUnSorted++)
            {
                if (arrayToSort[indexUnSorted] < smallest)
                {
                    smallestIndex = indexUnSorted;
                    smallest = arrayToSort[indexUnSorted];
                }
            }
            // swap the values
            int temp = arrayToSort[indexSorted];
            arrayToSort[indexSorted] = arrayToSort[smallestIndex];
            arrayToSort[smallestIndex] = temp;
        }
    }

    static void PrintSequence(int[] someArray, int startIndex, int endIndex)
    {
        Console.Write("{");
        for (int i = startIndex; i < endIndex; i++)
        {
            Console.Write(someArray[i] + ",");
        }
        Console.Write(someArray[endIndex]);
        Console.WriteLine("}");
    }
}
