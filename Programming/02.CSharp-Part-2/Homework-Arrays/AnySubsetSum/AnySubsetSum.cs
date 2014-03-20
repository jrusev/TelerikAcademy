using System;
using System.Collections.Generic;

class AnySubsetSum
{
    static void Main()
    {
        // We are given an array of integers and a number S.
        // Write a program to find if there exists a subset of the elements of the array that has a sum S.
        // Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)

        int[] numbers = { 2, 1, 2, 4, 3, 5, 2, 6 };
        Console.WriteLine(String.Join(", ", numbers));

        Console.Write("Enter a sum to find: ");
        int sum = int.Parse(Console.ReadLine());

        // we will find all possible combinations of elements and check their sum
        long allElements = (long)Math.Pow(2, numbers.Length); // 2^8=256
        bool subsetPresent = false;
        for (long elementSwitch = 1; elementSwitch < allElements; elementSwitch++) // [1;255]
        {
            long currentSum = 0;
            List<int> subset = new List<int>(); // use a List to add the elements of the subset
            for (int bit = 0; bit < numbers.Length; bit++)
            {
                // the '1' bits of elementSwitch are used to point which element to include in the subset
                // for example: if the bit at position 2 is ONE, the element with position 2 in the array is included in the subset
                // if elementSwitch is 7 (binary 0x00000111), the first three elements of the array will form the subset
                if (((elementSwitch >> bit) & 1) == 1)
                {
                    currentSum += numbers[bit];
                    subset.Add(numbers[bit]);
                }
            }
            if (currentSum == sum)
            {
                Console.WriteLine(String.Join(", ",subset.ToArray())); // print the subset
                subsetPresent = true;
            }
        }
        if (!subsetPresent)
        {
            Console.WriteLine("There is no subset of elements with sum {0}",sum);
        }
    }
}