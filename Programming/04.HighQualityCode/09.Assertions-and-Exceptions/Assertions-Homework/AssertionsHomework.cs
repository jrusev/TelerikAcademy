using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        // Better throw an exception, not assertion!
        Debug.Assert(arr != null, "Array is null!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        // postcondition: assert the array is sorted!
        AssertIsSorted(arr);
    }

    public static int BinarySearch<T>(T[] arr, T value)
    where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null!");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    [Conditional("DEBUG")]
    private static void AssertIsSorted<T>(T[] arr) where T : IComparable<T>
    {
        for (int ii = 0; ii < arr.Length - 1; ++ii)
        {
            Debug.Assert(arr[ii].CompareTo(arr[ii + 1]) <= 0, "Array isn't sorted.");
        }
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        // preconditions: 
        Debug.Assert(arr != null, "Array is null!");

        Debug.Assert(startIndex >= 0, "Start index is negative!");
        Debug.Assert(startIndex < arr.Length, "Start index is greater than array length!");

        Debug.Assert(endIndex >= 0, "End index is negative!");
        Debug.Assert(endIndex < arr.Length, "End index is greater than array length!");
        Debug.Assert(endIndex > startIndex, "End index is not greater than the start index!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        // postconditions:
        // Assert that arr[minElementIndex] is the minimal element (better with unit test)
        Debug.Assert(
          new Func<bool>(() =>
          {
              for (int i = startIndex; i <= endIndex; i++)
              {
                  if (arr[minElementIndex].CompareTo(arr[i]) > 0)
                  {
                      return false;
                  }
              }

              return true;
          })(),
          "Minimum element is not correctly identified.");

        return minElementIndex;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        // preconditions: 
        Debug.Assert(arr != null, "Array is null!");

        Debug.Assert(startIndex >= 0, "Start index is negative!");
        Debug.Assert(startIndex < arr.Length, "Start index is greater than array length!");

        Debug.Assert(endIndex >= 0, "End index is negative!");
        Debug.Assert(endIndex < arr.Length, "End index is greater than array length!");
        Debug.Assert(endIndex > startIndex, "End index is not greater than the start index!");

        // Assert the array is sorted!
        Debug.Assert(
            new Func<bool>(() =>
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i - 1].CompareTo(arr[i]) > 0)
                    {
                        return false;
                    }
                }

                return true;
            })(),
            "The array is not sorted.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }
}
