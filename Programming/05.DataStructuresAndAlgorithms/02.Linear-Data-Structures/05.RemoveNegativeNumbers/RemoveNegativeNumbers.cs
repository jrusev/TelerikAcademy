using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveNegativeNumbers
{
    // Write a program that removes from given sequence all negative numbers.
    private static void Main()
    {
        var list = new List<int>() { 2, 3, -1, 5, -4, -6, 9 };
        Console.WriteLine("List: {0}", string.Join(", ", list));

        // Either create a new sequence...
        var positiveNums = list.Where(x => x >= 0);

        // ... or remove from the current sequence
        list.RemoveAll(x => x < 0);

        Console.WriteLine("Negative numbers removed: {0}", string.Join(", ", positiveNums));
        ////Console.WriteLine("Negative numbers removed: {0}", string.Join(", ", list));
    }
}