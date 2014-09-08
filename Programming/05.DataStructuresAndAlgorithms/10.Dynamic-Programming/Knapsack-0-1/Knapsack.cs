using System;
using System.Collections.Generic;
using System.Linq;

// Write a program based on dynamic programming to solve the Knapsack Problem:
// you are given N products, each has weight Wi and costs Ci and a knapsack of capacity M
// and you want to put inside a subset of the products with highest cost and weight <= M.
// The numbers N, M, Wi and Ci are integers in the range [1...500].
class Knapsack
{
    internal struct Item { public string Name; public int Weight, Value;  }

    static void Main()
    {
        int maxCapacity = 10;
        var items = new List<Item>()
        {
            new Item() { Name = "beer", Weight = 3, Value = 2 }, new Item() { Name = "vodka", Weight = 8, Value = 12 },
            new Item() { Name = "cheese", Weight = 9, Value = 5 }, new Item() { Name = "nuts", Weight = 1, Value = 4 },
            new Item() { Name = "ham", Weight = 2, Value = 3 },new Item() { Name = "whiskey", Weight = 8, Value = 13 },
        };

        var takeItems = GetItems(items, maxCapacity);

        Console.WriteLine("Total weight: {0}", takeItems.Sum(i => i.Weight));
        Console.WriteLine("Highest cost: {0}", takeItems.Sum(i => i.Value));
        Console.WriteLine("Take items: {0}", string.Join(", ", takeItems.Select(i => i.Name).OrderBy(x => x)));        
    }

    public static IEnumerable<Item> GetItems(IList<Item> items, int maxCapacity)
    {
        // Fill table
        int[,] table = new int[items.Count + 1, maxCapacity + 1];
        for (int row = 1; row <= items.Count; row++)
        {
            var item = items[row - 1];
            for (int col = 0; col <= maxCapacity; col++)
            {
                if (item.Weight > col)
                {
                    table[row, col] = table[row - 1, col];
                }
                else
                {
                    table[row, col] = Math.Max(
                        table[row - 1, col],
                        table[row - 1, col - item.Weight] + item.Value);
                }
            }
        }

        // Find which items to take from the table
        var takeItems = new List<Item>();
        for (int row = items.Count, col = maxCapacity; row > 0; row--)
        {
            if (table[row, col] != table[row - 1, col])
            {
                takeItems.Add(items[row - 1]);
                col -= items[row - 1].Weight;
            }
        }

        return takeItems;
    }
}
