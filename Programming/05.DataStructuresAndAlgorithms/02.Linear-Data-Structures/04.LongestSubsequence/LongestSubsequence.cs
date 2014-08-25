using System;
using System.Collections.Generic;
using System.Linq;

public class LongestSubsequence
{
    // Write a method that finds the longest subsequence of equal numbers in given List<int>
    // and returns the result as new List<int>. Write a program to test whether the method works correctly.
    private static void Main()
    {
        int listSize = 32;

        var nums = CreateListOfRandomNumbers(listSize);
        Console.WriteLine("List: {0}", string.Join(", ", nums));

        var longestSubsequence = FindLongestSubsequence(nums);
        Console.WriteLine("Longest subsequence: {0}", string.Join(", ", longestSubsequence));
    }

    private static List<int> FindLongestSubsequence(List<int> nums)
    {
        if (nums.Count == 1)
        {
            return nums;
        }

        int longestStart = 0;
        int currentStart = 0;

        int longestLength = 0;
        int currentLength = 1;

        for (int i = 1; i < nums.Count; i++)
        {
            // If the current elements is different than the last,
            // or the end of the sequence is reached...
            if (nums[i] != nums[i - 1] || i == nums.Count - 1)
            {
                // ... check if the current sequence is longer than the longest
                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    longestStart = currentStart;
                }

                // Start a new sequence
                currentStart = i;
                currentLength = 1;
            }
            else
            {
                // The current element is equal to the last - continue sequence
                currentLength++;
            }
        }

        var longestSubsequence = nums.Skip(longestStart).Take(longestLength);
        return new List<int>(longestSubsequence);
    }

    private static List<int> CreateListOfRandomNumbers(int listSize)
    {
        var rand = new Random();
        var nums = new List<int>(listSize);
        for (int i = 0; i < listSize; i++)
        {
            // We use the list size as the upper limit for the random numbers.
            // This will allow some numbers to repeat.
            int randomNum = rand.Next(listSize / 8);
            nums.Add(randomNum);
        }

        return nums;
    }
}