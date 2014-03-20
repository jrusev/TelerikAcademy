using System;
using System.Diagnostics;

class GenerateVariations
{
    // Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
    // Example:	N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

    static int n; // number of elements (N)
    static int k; // number of elements in the variation (K)
    static int[] variation; // holds the variations

    static void Main()
    {
        Console.Write("Enter N (number of elements): ");
        n = int.Parse(Console.ReadLine());

        Console.Write("Enter K (number of elements in the variation): ");
        do
        {
            k = int.Parse(Console.ReadLine());
            if (k <= n)
                break;
            Console.Write("Enter K (smaller or equal to {0}): ", n);
        }
        while (true);

        variation = new int[k];
        Variations(0);
    }

    static void Variations(int position)
    {
        for (int i = 0; i < n; i++)
        {
            variation[position] = i + 1;
            if (position == k - 1)
                Console.WriteLine("{{ {0} }}", String.Join(", ", variation)); // prints the variation
            else
                Variations(position + 1);
        }
    }
}