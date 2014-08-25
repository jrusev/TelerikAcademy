using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class MajorantSpeedTest
{
    // Test time complexity of algorithms for finding the majorant of an array of size N.
    private delegate int? TestMethod(int[] arr);

    private static void Main()
    {
        int repeat = 10;
        int arraySize = 1000000; // 10000000 -> ~0.5 seconds
        var testArray = BuildTestArray(arraySize);
        ////Console.WriteLine(string.Join(" ", arr));
        TimeSpan elapsed;

        elapsed = TestRunTime(GetMajorantWithLINQ, testArray, repeat);
        Console.WriteLine("LINQ: {0}", elapsed);

        elapsed = TestRunTime(GetMajorantWithStack, testArray, repeat);
        Console.WriteLine("STCK: {0}", elapsed);

        elapsed = TestRunTime(GetMajorantWithSystemStack, testArray, repeat);
        Console.WriteLine("SSTK: {0}", elapsed);
    }

    private static TimeSpan TestRunTime(TestMethod testMethod, int[] arr, int repeat)
    {
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < repeat; i++)
        {
            testMethod(arr);
        }

        sw.Stop();
        return sw.Elapsed;
    }

    private static int[] BuildTestArray(int size)
    {
        int majorant = -1;
        var rand = new Random();
        var arr = new int[size];
        for (int i = 0; i < arr.Length; i++)
        {
            if (rand.Next(0, 100) > 45)
            {
                arr[i] = majorant;
            }
            else
            {
                arr[i] = rand.Next(1, 10);
            }
        }

        return arr;
    }

    private static int? GetMajorantWithLINQ(int[] numbers)
    {
        var frequencyDict = numbers.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var majorant = frequencyDict.FirstOrDefault(p => p.Value > numbers.Length / 2).Key;
        if (majorant == 0)
        {
            return null;
        }

        return majorant;
    }

    private static int? GetMajorantWithStack(int[] numbers)
    {
        int? majorityNum = null;
        int stack = 0;

        foreach (int num in numbers)
        {
            if (stack == 0)
            {
                majorityNum = num;
            }

            stack += (num == majorityNum) ? 1 : -1;
        }

        int majorityNumCount = numbers.Count(n => n == majorityNum);
        if (!(majorityNumCount > (numbers.Length / 2)))
        {
            // The array has no majorant!
            majorityNum = null;
        }

        return majorityNum;
    }

    private static int? GetMajorantWithSystemStack(int[] numbers)
    {
        var stack = new Stack<int>();
        foreach (var num in numbers)
        {
            if (stack.Count == 0)
            {
                stack.Push(num);
            }
            else
            {
                if (num == stack.Peek())
                {
                    stack.Push(num);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        if (stack.Count == 0)
        {
            // The array has no majorant!
            return null;
        }

        int majorityNum = stack.Pop();
        int majorityNumCount = 0;

        foreach (var num in numbers)
        {
            if (majorityNum == num)
            {
                majorityNumCount++;
            }
        }

        ////majorityNumCount = numbers.Count(n => n == majorityNum);

        if (majorityNumCount < (numbers.Length / 2) + 1)
        {
            // The array has no majorant!
            return null;
        }

        return majorityNum;
    }
}