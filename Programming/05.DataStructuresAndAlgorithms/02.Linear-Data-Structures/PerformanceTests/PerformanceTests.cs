using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class PerformanceTests
{
    // Write a program that removes from given sequence all numbers that occur odd number of times.
    // Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
    private static void Main()
    {
        int numCount = 1000000;
        var nums = GenerateList(numCount);
        int repeat = 10;

        TestPerformance(RemoveOddOccurences1, nums, repeat, "RemoveOddOccurences1");
        TestPerformance(RemoveOddOccurences2, nums, repeat, "RemoveOddOccurences2");
        TestPerformance(RemoveOddOccurences3, nums, repeat, "RemoveOddOccurences3");
    }

    public static IEnumerable<T> RemoveOddOccurences1<T>(IEnumerable<T> collection)
    {
        var dict = collection.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count() % 2 == 0);
        var filtered = collection.Where(x => dict[x]);
        return filtered;
    }

    public static IEnumerable<T> RemoveOddOccurences2<T>(IEnumerable<T> collection)
    {
        var oddOccurrences = new HashSet<T>();
        var evenOccurrences = new HashSet<T>();

        foreach (var element in collection)
        {
            if (oddOccurrences.Add(element))
            {
                evenOccurrences.Remove(element);
            }
            else
            {
                oddOccurrences.Remove(element);
                evenOccurrences.Add(element);
            }
        }

        var filtered = collection.Where(e => evenOccurrences.Contains(e));
        return filtered;
    }

    public static IEnumerable<T> RemoveOddOccurences3<T>(IEnumerable<T> collection)
    {
        var occurs = new Dictionary<T, int>();
        foreach (var item in collection)
        {
            int value;
            occurs[item] = occurs.TryGetValue(item, out value) ? value + 1 : 1;
        }

        var filtered = collection.Where(x => occurs[x] % 2 == 0);
        return filtered;
    }

    private static IEnumerable<int> GenerateList(int numCount)
    {
        var rand = new Random();
        var nums = new List<int>();
        var maxNum = numCount / 10;
        for (int i = 0; i < numCount; i++)
        {
            nums.Add(rand.Next(maxNum));
        }

        //nums = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

        return nums;
    }

    private static void TestPerformance<T>(
        Func<IEnumerable<T>, IEnumerable<T>> algorithm,
        IEnumerable<T> nums,
        int repeat,
        string title)
    {
        Console.Write("{0, -25}", title);
        var sw = Stopwatch.StartNew();

        for (int i = 0; i < repeat; i++)
        {
            var result = algorithm(nums);
            //Console.WriteLine(string.Join(", ", result));
        }

        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }
}