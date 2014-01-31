using System;
class KSubsetSum
{
    // Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
    // Find in the array a subset of K elements that have sum S or indicate about its absence.

    // declare the variables here so they can be seen by all methods
    static int[] array; // the array of integers
    static int n; // size of the array
    static int k; // size of the subset
    static int sum; // sum of the subset
    static int[] subset; // holds the subset
    static int countSubsets; // counts the subsets with sum S

    static void Main()
    {
        Console.Write("Do you want to manually enter the elements of the array (Y/N)?");
        if (Console.ReadKey().Key == ConsoleKey.Y)
            EnterElementsManually();
        else
            EnterElementsAutomatically();

        Console.WriteLine("Array: {0}", String.Join(", ", array)); // prints the array
        Console.Write("Size K of the subset (1<K<={0}) = ", n);
        k = int.Parse(Console.ReadLine());
        Console.Write("Sum of the subset of {0} elements = ", k);
        sum = int.Parse(Console.ReadLine());

        subset = new int[k]; // will hold the subset
        countSubsets = 0;
        // find all combinations of K elements from the array
        FindSubsets(0, 0, 0);
        if (countSubsets == 0)
            Console.WriteLine("There are no subsets of {0} element{1} with sum {2}.", k, k > 1 ? "s" : "", sum);
        else
            Console.WriteLine("{0} subset{1} with sum {2}.", countSubsets, countSubsets > 1 ? "s" : "", sum);
    }

    static void FindSubsets(int StartIndex, long lastSubsetSum, int count)
    {
        // the method calls itself K times, each time adding a different element to the subset
        // on the third call, the sum of the elements is checked
        for (int i = StartIndex; i < array.Length; i++)
        {
            long currentSubsetSum = lastSubsetSum + array[i];
            subset[count] = array[i];
            if (count == k - 1)
            {
                if (currentSubsetSum == sum)
                {
                    // print the subset elements, separated by commas
                    Console.WriteLine("{ " + String.Join(", ", subset) + " }");
                    countSubsets++;
                }
            }
            else
            {
                FindSubsets(i + 1, currentSubsetSum, count + 1);
            }
        }
    }

    static void EnterElementsManually()
    {
        Console.WriteLine();
        Console.Write("Enter number of elements: ");
        n = int.Parse(Console.ReadLine());
        array = new int[n];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }

    static void EnterElementsAutomatically()
    {
        // saves some time when testing
        Console.WriteLine();
        Console.WriteLine("Smart choice!");
        array = new int[] { 2, 1, 2, 4, 3, 5, 2, 6 };
        n = array.Length;
    }
}