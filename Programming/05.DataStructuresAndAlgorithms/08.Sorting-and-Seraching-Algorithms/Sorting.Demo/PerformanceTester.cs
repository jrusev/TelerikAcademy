using Sorting.Lib;
using System;
using System.Diagnostics;

namespace Sorting.Demo
{
    public static class PerformanceTester
    {
        private static readonly Random Rand = new Random();
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        public static void Test(params ISorter<int>[] sorters)
        {
            var randomArray = GenerareRandomArray(10000);

            foreach (var sorter in sorters)
            {
                DisplayTestResult(GetClassName(sorter), () =>
                {
                    new SortableCollection<int>(randomArray).Sort(sorter);
                });
            }
        }

        private static int[] GenerareRandomArray(int count)
        {
            var arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = Rand.Next(count);
            }

            return arr;
        }

        private static void DisplayTestResult(string title, Action action)
        {
            Console.Write("{0, -15}: ", title);
            Stopwatch.Restart();

            action();

            Stopwatch.Stop();
            Console.WriteLine("{0,7:F2}ms", Stopwatch.Elapsed.TotalMilliseconds);
        }

        private static string GetClassName(object obj)
        {
            string genericName = obj.GetType().Name;
            string nongenericName = genericName.Substring(0, genericName.LastIndexOf('`'));
            return nongenericName;
        }
    }
}
