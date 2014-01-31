using System;
using System.Diagnostics;

class GenerateCombinations
{
    // Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].
    // Example:	N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}


    static int n; // number of elements (N)
    static int k; // number of elements in the combination (K)
    static int[] combination; // holds the combination

    static void Main()
    {
        Console.Write("Enter N (number of elements): ");
        n = int.Parse(Console.ReadLine());

        Console.Write("Enter K (elements in the combination): ");
        do
        {
            k = int.Parse(Console.ReadLine());
            if (k <= n)
                break;
            Console.Write("Enter K (smaller or equal to {0}): ", n);
        }
        while (true);

        combination = new int[k];
        Combinate(0,0);
    }

    static void Combinate(int position, int next)
    {
        for (int i = next; i < n; i++)
        {
            combination[position] = i + 1;
            if (position == k - 1)
                Print(combination);
            else
                Combinate(position + 1, i + 1);
        }
    }

    static void Print(int[] array)
    {
        Console.WriteLine("{{ {0} }}", String.Join(", ", array));
    }
}