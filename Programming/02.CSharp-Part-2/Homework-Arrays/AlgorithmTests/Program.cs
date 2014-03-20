using System;
using System.Diagnostics;

class AlgorithmTests
{
    static void Main()
    {
        int maxTests = 10;
        long totalElapsed1 = 0;
        long totalElapsed2 = 0;

        int testArraySize = 100000; // increase this to work with longer arrays
        int[] numbers1 = new int[testArraySize];
        int[] numbers2 = new int[testArraySize];
        for (int repeat = 0; repeat <= maxTests; repeat++)
        {
            Random rand = new Random();
            for (int i = 0; i < numbers1.Length; i++)
            {
                numbers1[i] = numbers2[i] = rand.Next(int.MinValue, int.MaxValue);
            }

            Stopwatch sw1 = Stopwatch.StartNew();
            //Array.Sort(numbers1);            

            int[] temp = new int[numbers1.Length];
            MergeSortAlgorithm.MergeSort(numbers1, temp, 0, numbers1.Length - 1);

            //numbers1 = MergeSortAlgorithm.MergeSort(numbers1);
            //SortArraySelection.SelectionSort(numbers);

            sw1.Stop();
            totalElapsed1 += sw1.ElapsedMilliseconds;

            bool arrayIsSorted1 = IsSorted(numbers1);
            if (!arrayIsSorted1)
            {
                Console.WriteLine( "Unsorted array!");
                break;
            }
            ///////////////////////////////////////////////////////
            Stopwatch sw2 = Stopwatch.StartNew();

            QuickSortProblem.QuickSort(numbers2, 0, numbers1.Length - 1);

            sw2.Stop();
            totalElapsed2 += sw2.ElapsedMilliseconds;

            bool arrayIsSorted2 = IsSorted(numbers2);
            if (!arrayIsSorted2)
            {
                Console.WriteLine("Unsorted array!");
                break;
            }
        }
        Console.WriteLine("Average time1: {0} ms", (float)totalElapsed1 / maxTests);
        Console.WriteLine("Average time2: {0} ms", (float)totalElapsed2 / maxTests);
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
            {
                return false;
            }
        }
        return true;
    }
}