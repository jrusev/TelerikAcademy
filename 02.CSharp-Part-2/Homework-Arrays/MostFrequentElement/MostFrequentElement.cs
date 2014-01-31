using System;

class MostFrequentElement
{
    static void Main()
    {
        // Write a program that finds the most frequent number in an array.
        // Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

        int[] array = new int[20];
        Random randomGenerator = new Random();
        for (int index = 0; index < array.Length; index++)
        {
            array[index] = randomGenerator.Next(0, 10); // fill the array with random numbers from 0 to 10
        }
        PrintArray(array);

        // we start from the left and find all numbers equal to the first
        // when we find such numbers we swap them with the elemenents after the first
        // when we get to the end, all numbers equal to the first will be at the beginning of the array
        // we then go to the next number not equal to the first
        // we keep swapping, until all equal elements are stacked next to each other
        // for example this array: { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 }
        // will be transformed to: { 4, 4, 4, 4, 4, 3, 3, 1, 1, 1, 2, 2, 9 }
        // each time we get to the end of the array, we compare the current count with the max count
        // if it is bigger, we have a new max count and a new most frequent element

        int maxCount = 0;
        int mostFrequent = array[0];

        for (int i = 0; i < array.Length; i++)
        {
            int currentCount = 1;
            int indexToReplace = i + 1;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] == array[i])
                {
                    array[j] = array[i + currentCount];
                    array[i + currentCount] = array[i]; // this swap is not necessary for the algo to work
                    currentCount++;
                }
            }
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                mostFrequent = array[i];
            }
            i += currentCount - 1;
        }
        Console.WriteLine("\nEqual elements stacked next to each other (not in order of frequency):");
        PrintArray(array);
        Console.WriteLine("\nMost frequent: {0} ({1} times)", mostFrequent, maxCount);

    }

    static void PrintArray(int[] someArray)
    {
        Console.Write("{");
        for (int i = 0; i < someArray.Length - 1; i++)
        {
            Console.Write(someArray[i] + ",");
        }
        Console.Write(someArray[someArray.Length - 1]);
        Console.WriteLine("}");
    }
}