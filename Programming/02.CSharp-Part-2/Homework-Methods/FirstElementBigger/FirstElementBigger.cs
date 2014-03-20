using System;

class FirstElementBigger
{
    static void Main()
    {
        // Write a method that returns the index of the first element in array that is bigger than its neighbors,
        // or -1, if there’s no such element.

        int[] numbers = new int[10];
        Random rand = new Random();

        while (true) // Let's test many arrays (press CTL+C to exit)
        {
            // Fill the array with random numbers from 0 to 9
            for (int i = 0; i < numbers.Length; i++) numbers[i] = rand.Next(10);

            int checkIndex = FirstBiggerThanNeighbors(numbers);
            if (checkIndex == -1)
                Console.WriteLine("There are no elements in the array that are bigger than its neighbors.");
            else
                Console.WriteLine("The first element that is bigger than its neighbors is at position {0}.", checkIndex);

            // Print the array
            Console.Write("Array:");
            for (int i = 0; i < numbers.Length; i++)
            {
                // Print the found element in red
                if (i == checkIndex) Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0,3}", numbers[i]);
                Console.ResetColor();
            }
            Console.WriteLine("\n");
            Console.ReadKey(true);
        }
    }

    static int FirstBiggerThanNeighbors(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
            if (IsBiggerThanNeighbors(array, i)) return i;
        return -1;
    }

    static bool IsBiggerThanNeighbors(int[] array, int checkIndex)
    {
        if (array.Length < 2) // empty array or just one element
        {
            return false;
        }
        else if (checkIndex == 0) // first element
        {
            return array[checkIndex] > array[checkIndex + 1];
        }
        else if (checkIndex == array.Length - 1) // last element
        {
            return array[checkIndex] > array[checkIndex - 1];
        }
        else
        {
            return (array[checkIndex] > array[checkIndex + 1]) && (array[checkIndex] > array[checkIndex - 1]);
        }
    }
}