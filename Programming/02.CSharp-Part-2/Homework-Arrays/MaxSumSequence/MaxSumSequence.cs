using System;

class MaxSumSequence
{
    static void Main()
    {
        // Write a program that finds the sequence of maximal sum in given array.
        // Example:	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}

        int[] numbers = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        Console.Write("Numbers: ");
        PrintSequence(numbers, 0, numbers.Length - 1); // print the entire array

        // Kadane's algorithm
        int max_so_far = numbers[0], max_ending_here = numbers[0];
        int begin = 0;
        int begin_temp = 0;
        int end = 0;
        for (int i = 1; i < numbers.Length; i++) // one loop!
        {
            if (max_ending_here < 0)
            {
                max_ending_here = numbers[i];
                begin_temp = i;
            }
            else
            {
                max_ending_here += numbers[i];
            }

            if (max_ending_here > max_so_far)
            {
                max_so_far = max_ending_here;
                begin = begin_temp;
                end = i;
            }
        }

        Console.WriteLine("Maximal sum = {0}", max_so_far);
        Console.Write("Sequence: ");
        PrintSequence(numbers, begin, end); // print the sequence with max sum
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

