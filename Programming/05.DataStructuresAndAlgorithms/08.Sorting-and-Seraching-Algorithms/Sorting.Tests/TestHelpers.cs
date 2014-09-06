using System;
using System.Collections.Generic;
using System.Linq;

internal enum ArrayOptions 
{
    Random,
    Sorted,
    Reversed
}

internal static class TestHelpers
{
    private static readonly Random Rand = new Random();

    public static bool IsSorted<T>(this IEnumerable<T> seq)
    {
        return seq.OrderBy(x => x, Comparer<T>.Default)
                  .SequenceEqual(seq);
    }

    public static bool SameContents<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2)
    {
        return seq1.OrderBy(x => x, Comparer<T>.Default).SequenceEqual(
               seq2.OrderBy(x => x, Comparer<T>.Default));
    }

    public static int[] GenerateIntArray(ArrayOptions option, int length)
    {
        var arr = new int[length];
        for (var i = 0; i < length; ++i)
        {
            arr[i] = Rand.Next();
        }

        if (option == ArrayOptions.Sorted)
        {
            Array.Sort(arr);
        }

        if (option == ArrayOptions.Reversed)
        {
            Array.Sort(arr);
            Array.Reverse(arr);
        }

        return arr;
    }
}