using System;

class MaximalSequence
{
    static void Main()
    {
        // Write a program that finds the maximal sequence of equal elements in an array.
        // Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

        int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };

        int bestIndex = 0;
        int currentBestIndex = 0;
        int bestLength = 1;
        int currentBestLength = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i-1])
            {
                currentBestLength++;
                if (currentBestLength > bestLength )
                {
                    bestLength = currentBestLength;
                    bestIndex = currentBestIndex;
                }                
            }
            else
            {
                currentBestLength = 1;
                currentBestIndex = i;
            }
        }
        PrintSequence(ref array, bestIndex, bestIndex + bestLength - 1);
    }

    static void PrintSequence(ref int[] array,int startIndex, int endIndex)
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