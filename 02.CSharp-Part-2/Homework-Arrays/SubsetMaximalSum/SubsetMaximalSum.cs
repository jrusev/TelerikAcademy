using System;

class SubsetMaximalSum
{
    static void Main()
    {
        // Write a program that reads two integer numbers N and K and an array of N elements from the console.
        // Find in the array those K elements that have maximal sum.

        Console.Write("Number of elements in the array N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Number of elements in the subset K (K<N) = ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(array); // the greatest sum is the sum of the greatest K elements, which will be the last K elements after we sort the array
        Console.Write("The {0} elements with the greatest sum are: ",k);
        PrintSequence(ref array, array.Length - k, array.Length - 1); // print the last K elements of the sorted array
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