using System;

class SequenceWithGivenSum
{
    static void Main()
    {
        // Write a program that finds in given array of integers a sequence of given sum S (if present).
        // Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

        int[] array = {4, 3, 1, 4, 2, 5, 8};
        PrintSequence(array, 0, array.Length - 1);

        Console.Write("Sum = ");
        int sum = int.Parse(Console.ReadLine());

        bool sumIsPresent = false;
        for (int indexStart = 0; indexStart < array.Length; indexStart++)
        {
            int currentSum = 0;            
            for (int indexEnd = indexStart; indexEnd < array.Length; indexEnd++)
            {
                currentSum += array[indexEnd];
                if (currentSum == sum)
                {
                    PrintSequence(array, indexStart, indexEnd);
                    sumIsPresent = true;
                    break;
                }
                else if (currentSum > sum)
                    break;
            }
        }
        if (!sumIsPresent)
        {
            Console.WriteLine("No sequence has a sum of {0}.",sum);
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