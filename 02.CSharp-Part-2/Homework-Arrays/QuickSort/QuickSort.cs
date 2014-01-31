using System;

public class QuickSortProblem
{
    // Write a program that sorts an array of strings using the quick sort algorithm.

    static void Main()
    {
        int[] numbers = { 3, 7, 2, 9, 5, 2, 6, 1 };
        string[] strings = { "fox", "dog", "fish", "catfish", "cat", "car", "box", "ant", "Dino" };

        // sort integer array
        Console.Write("Unsorted: ");
        PrintAnyArray(numbers);

        QuickSort(numbers, 0, numbers.Length - 1);

        Console.Write("Sorted:   ");
        PrintAnyArray(numbers);

        // sort string array
        Console.Write("Unsorted: ");
        PrintAnyArray(strings);

        QuickSort(strings, 0, strings.Length - 1);

        Console.Write("Sorted:   ");
        PrintAnyArray(strings);

        // check if the arrays are successfully sorted
        bool numberArrayIsSorted = IsSorted(numbers);
        bool stringArrayIsSorted = IsSorted(strings);
        Console.WriteLine(numberArrayIsSorted ? "The number array is sorted." : "The number array is not sorted.");
        Console.WriteLine(stringArrayIsSorted ? "The string array is sorted." : "The string array is not sorted.");
    }

    public static void QuickSort(int[] numbers, int start, int end)
    {
        // Partitions the array into left and right sub-arrays
        // At each step the element that splits the array
        // is at its correct position (the element at position pIndex)
        // Then makes a recursive call to partition the sub-arrays
        // Stops when it gets to sub-arrays of size 0 or 1
        // At that point the array is fully sorted
        // because all elements are at their correct positions
        if (start < end)
        {
            // Randomly select an element called "pivot"
            int pivot = numbers[end]; // in this case the last element

            // Rearrange the array so that all elements smaller than the pivot
            // are to the left of the pivot (not necessarily sorted)
            // and all elements larger than the pivot are to the right
            int pIndex = start;
            for (int i = start; i < end; i++)
            {
                if (numbers[i] <= pivot)
                {
                    // swap
                    int temp = numbers[i];
                    numbers[i] = numbers[pIndex];
                    numbers[pIndex] = temp;

                    pIndex++;
                }
            }
            // final swap to put the pivot at its correct postion (pIndex)
            numbers[end] = numbers[pIndex];
            numbers[pIndex] = pivot;
            // Recursive calls for the subarrays left and right of the pivot
            QuickSort(numbers, start, pIndex - 1);
            QuickSort(numbers, pIndex + 1, end);
        }
    }

    public static void QuickSort(string[] stringArray, int start, int end)
    {
        // works with strings
        if (start < end)
        {
            int pIndex = QuickPartition(stringArray, start, end);
            QuickSort(stringArray, start, pIndex - 1);
            QuickSort(stringArray, pIndex + 1, end);
        }
    }

    static int QuickPartition(string[] strings, int start, int end)
    {
        // works with strings
        string pivot = strings[end];
        int pIndex = start;
        for (int i = start; i < end; i++)
        {
            //if (CompareStrings(strings[i], pivot) <= 0)
            if (strings[i].CompareTo(pivot) <= 0) // strings[i] <= pivot
            {
                SwapElements(strings, i, pIndex);
                pIndex++;
            }
        }
        SwapElements(strings, end, pIndex);
        return pIndex;
    }

    static void SwapElements<T>(T[] data, int a, int b)
    {
        // swaps two elements in an array
        // use like this: SwapElements(array, index1, index2);
        T temp = data[a];
        data[a] = data[b];
        data[b] = temp;
    }

    static void Swap<K>(ref K a, ref K b)
    {
        // swaps any two variables, including elements in an array
        // use like this: Swap(ref variableA, ref variableB);
        // "FUNDAMENTALS OF COMPUTER PROGRAMMING WITH C#", p.604
        K oldA = a;
        a = b;
        b = oldA;
    }

    static int CompareStrings(string stringA, string stringB)
    {
        /* Compares two strings lexicographically (letter by letter).
         * 
         * In lexicographic order the elements are compared one by one starting from the very left.
         * If the elements are not the same, the array, whose element is smaller (comes earlier in the alphabet), comes first.
         * If the elements are equal, the next character is compared.
         * If the end of one of the arrays is reached, without finding different elements,
         * the shorter array is the smaller (comes earlier lexicographically).
         * If all elements are equal, the arrays are equal.
         */

        // convert to lowercase
        string a = stringA.ToLower();
        string b = stringB.ToLower();

        // compare symbol by symbol
        for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
        {
            if (a[i] < b[i])
                return -1;  // stringA < stringB
            if (a[i] > b[i])
                return 1; // stringA > stringB
        }
        // the program will get here if all the characters that were compared were equal
        if (a.Length == b.Length)
            return 0; // The arrays are equal
        else
            return (a.Length > b.Length) ? 1 : -1; // finally compare by length
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    static bool IsSorted(string[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (CompareStrings(array[i], array[i - 1]) <= 0)
            {
                return false;
            }
        }
        return true;
    }

    static void PrintAnyArray<T>(T[] array)
    {
        // prints the array elements separated by commas
        Console.WriteLine(String.Join(", ", array));
    }
}