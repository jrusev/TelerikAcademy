using System;
using System.Collections.Generic;

class LongestIncreasingSubarray
{
    static void Main()
    {
        // Write a program that reads an array of integers
        // and removes from it a minimal number of elements in such way that
        // the remaining array is sorted in increasing order. Print the remaining sorted array.
        // Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}

        List<int> numbers = new List<int>() { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        List<int> result = new List<int>(); // will hold the longest sorted sub-array

        // we will find all possible subsets
        // and make sure they include only increasing elements
        // if all elements are increasing, we compare the length of the subset with the best length
        // the longest subset with increasing elements is the solution 

        long totalSubsets = (int)Math.Pow(2, numbers.Count) - 1;
        int bestLength = 1; // there must be at least one element to have a sequence!
        for (long bitSelector = 1; bitSelector <= totalSubsets; bitSelector++)
        {
            List<int> subset = new List<int>();
            bool isIncreasing = true;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (((bitSelector >> i) & 1) == 1)
                {
                    subset.Add(numbers[i]); // add the element
                    if (subset.Count >= 2)
                    {
                        // compare the last two elements
                        if (numbers[i] < subset[subset.Count - 2])
                        {
                            isIncreasing = false;
                            break;
                        }
                    }
                }
            }
            if (isIncreasing && subset.Count > bestLength)
            {
                result = subset;
                bestLength = subset.Count;
            }
        }
        if (result.Count > 1)
            Console.WriteLine(String.Join(", ", result)); // prints the sequence separated by commas
        else
            Console.WriteLine("There are no increasing sequences!");
    }  
}