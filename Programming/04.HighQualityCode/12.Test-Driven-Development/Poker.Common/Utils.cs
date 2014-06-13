namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class Utils
    {
        // assumes the sequences are of equal length
        internal static int CompareSequences<T>(IEnumerable<T> seq1, IEnumerable<T> seq2, Func<T, int> f)
        {
            var en1 = seq1.GetEnumerator();
            var en2 = seq2.GetEnumerator();
            while (en1.MoveNext() && en2.MoveNext())
            {
                var cmp = f(en1.Current).CompareTo(f(en2.Current));
                if (cmp != 0)
                {
                    return cmp;
                }
            }

            return 0;
        }
    }
}