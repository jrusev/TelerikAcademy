using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    internal static class Utils
    {
        static public IEnumerable<T> Duplicates<T>(this IEnumerable<T> seq)
        {
            return from card in seq
                   group card by card
                       into g
                       where g.Count() > 1
                       select g.First();
        }

        // assumes the sequences are of equal length
        static internal int CompareSequences<T>(IEnumerable<T> seq1, IEnumerable<T> seq2, Func<T, int> f) 
        {
            var en1 = seq1.GetEnumerator();
            var en2 = seq2.GetEnumerator();
            while (en1.MoveNext() && en2.MoveNext())
            {
                var cmp = f(en1.Current).CompareTo(
                          f(en2.Current));
                if (cmp != 0)
                    return cmp;
            }
            return 0;
        }
    }
}