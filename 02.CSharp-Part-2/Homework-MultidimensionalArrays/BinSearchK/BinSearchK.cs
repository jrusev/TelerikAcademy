using System;

class BinSearchK
{
    static void Main()
    {
        // Write a program, that reads from the console an array of N integers and an integer K,
        // sorts the array and using the method Array.BinSearch()
        // and finds the largest number in the array which is ≤ K. 

        // let's hard code the array for faster testing
        int[] numbers = { 5, 6, 8, 70, 15, 71, 9, 34, 8, 1, 4};

        Array.Sort(numbers);
        Console.WriteLine(String.Join(", ", numbers)); // print the array

        // allow the user multiple searches to test the program
        while (true)
        {
            Console.Write("\nPlease enter a number to search: ");
            int k = int.Parse(Console.ReadLine());

            int index = Array.BinarySearch(numbers, k);
            if (index < 0) index = ~index - 1; // bitwise complement of the index minus 1

            if (index == -1)
                Console.WriteLine("There are no numbers in the array which are less than or equal to {0}", k);
            else
                Console.WriteLine("Largest number in the array which is less than or equal to {0} is {1}.", k, numbers[index]);   
        }    
    }
}
