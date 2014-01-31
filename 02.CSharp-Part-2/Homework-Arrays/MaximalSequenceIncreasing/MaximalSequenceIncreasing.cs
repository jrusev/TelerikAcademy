using System;

class MaximalSequenceIncreasing
{
    static void Main()
    {
        // Write a program that finds the maximal increasing sequence in an array.
        // Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

        int[] array = { 3, 2, 3, 4, 2, 2, 4 }; // {2, 3, 4}
        if (array.Length <= 0)
        {
            Console.WriteLine("Empty array!");
            Console.ReadKey();
            return;
        }
        int bestLen = 1;
        int currLen = 1;
        int bestSequenceStart = 0;
        int currSequenceStart = 0;

        for (int index = 1; index < array.Length; index++)
        {
            if (array[index] > array[index-1])
            {
                currLen++;
                if (currLen > bestLen)
                {
                    bestLen = currLen;
                    bestSequenceStart = currSequenceStart;
                }
            }
            else
            {
                currLen = 1;
                currSequenceStart = index;
            }
        }
        PrintSequence(ref array, bestSequenceStart, bestSequenceStart + bestLen - 1); // start index and end index of the sequence
    }

    static void PrintSequence(ref int[] array, int startIndex, int endIndex)
    {
        Console.Write("{");
        for (int i = startIndex; i < endIndex; i++)
        {
            Console.Write(array[i] + ",");
        }
        Console.Write(array[endIndex]);
        Console.WriteLine("}");
    }
}