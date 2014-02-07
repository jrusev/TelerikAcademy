using System;
using System.Collections.Generic;

// Implement a set of extension methods for IEnumerable<T>
// that implement the following group functions:
// sum, product, min, max, average.
public static class IEnumerableExtensions
{
    /// <summary>
    /// Computes the sum of a sequence of values.
    /// </summary>
    public static T Sum<T>(this IEnumerable<T> collection)
    {
        T sum = default(T);
        foreach (var item in collection)
        {
            sum += (dynamic)item;
        }

        return sum;
    }

    /// <summary>
    /// Computes the average of a sequence of values.
    /// </summary>
    public static T Average<T>(this IEnumerable<T> collection)
    {
        dynamic sum = 0;
        int count = 0;
        foreach (var item in collection)
        {
            sum += (dynamic)item;
            count++;
        }

        return sum / count;
    }

    /// <summary>
    /// Computes the product of a sequence of values.
    /// </summary>
    public static T Product<T>(this IEnumerable<T> collection)
    {
        dynamic product = 1;
        foreach (var item in collection)
        {
            product *= (dynamic)item;
        }

        return (T)product;
    }

    /// <summary>
    /// Computes the minimum of a sequence of values.
    /// </summary>
    public static T Min<T>(this IEnumerable<T> collection)
        where T: IComparable
    {
        dynamic min = long.MaxValue;
        foreach (var item in collection)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }

        return min;
    }

    /// <summary>
    /// Computes the maximum of a sequence of values.
    /// </summary>
    public static T Max<T>(this IEnumerable<T> collection)
        where T: IComparable
    {
        dynamic max = long.MinValue;
        foreach (var item in collection)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }
}