using System;
using System.Diagnostics;

class Permutations
{
    // Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
    // Example:	n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

    static int limit; // the upper bound of the range (N)
    static bool[] used; // marks the used numbers
    static int[] numbers; // holds the permutations
    static int[] pm; // the permutation

    static void Main()
    {
        Console.Write("Enter N (the upper limit of the range): ");
        limit = int.Parse(Console.ReadLine());

        numbers = new int[limit];
        used = new bool[limit];
        Permut1(0);

        Console.WriteLine("Variant 2:");
        pm = new int[limit];
        for (int i = 0; i < limit; i++) pm[i] = i + 1;
        Permut2(limit);
    }
    
    static void Permut1(int position)
    {
        for (int i = 0; i < limit; i++)
        {
            if (used[i] == false) // checks to see if the number is already used
            {
                numbers[position] = i + 1;
                if (position == limit - 1)
                {
                    Console.WriteLine("{{ {0} }}", String.Join(", ", numbers)); // prints the permutaton
                    return;
                }
                used[i] = true;
                Permut1(position + 1);
                used[i] = false;
            }
        }
    }

    static void Permut2(int k)
    {
        // from "Programming = ++Algorithms", P. Nakov, page 83
        if (k == 0) Console.WriteLine("{{ {0} }}", String.Join(", ", pm)); // prints the permutaton
        else
        {
            Permut2(k - 1);
            for (int i = 0; i < k - 1; i++)
            {
                int swap = pm[i];
                pm[i] = pm[k - 1];
                pm[k - 1] = swap;

                Permut2(k - 1);

                swap = pm[i];
                pm[i] = pm[k - 1];
                pm[k - 1] = swap;
            }
        }
    }
}