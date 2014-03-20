using System;

class BinarySearch
{
    static void Main()
    {
        // Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm.

        // generate an array
        int[] numbers = new int[10];
        Random rand = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            // fill with random numbers from 1 to 100
            numbers[i] = rand.Next(1, 100);
        }

        // sort the array
        Array.Sort(numbers);

        // print the array with the indexes
        Console.Write("Index: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0,2} ", i);
        }
        Console.WriteLine();
        Console.Write("Value: ");
        foreach (var number in numbers)
        {
            Console.Write("{0,2} ", number);
        }
        Console.WriteLine();

        while (true)
        {
            Console.Write("Enter an element to search: ");
            int key = int.Parse(Console.ReadLine());

            int index = MyBinarySearch(numbers, key);
            if (index < 0 ) // BinarySearchElement returns -1 if the element is not found
            {
                Console.WriteLine("Element not found!");
            }
            else
            {
                Console.WriteLine("The index of the element is: {0}", index);
            }
            Console.WriteLine();
        }
    }

    static int MyBinarySearch(int[] numbers, int key)
    {
        // takes an array of integers and a value to search
        // returns the index of the element in the array
        // or -1 if the element is not found
        // the array must be sorted before calling this method
        int low = 0;
        int high = numbers.Length - 1;
        while (high >= low)
        {
            int mid = low + (high - low) / 2; // guarantees no overflow
            if (key == numbers[mid])
                return mid;
            else if (key < numbers[mid])
                high = mid - 1;
            else
                low = mid + 1;
        }
        return -1;
    }
}