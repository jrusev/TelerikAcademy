namespace Sorting.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var arr = collection.ToArray();
            QuickSort(arr, 0, collection.Count - 1);
            // Copy the sorted array back to the collection
            for (int i = 0; i < collection.Count; i++)
                collection[i] = arr[i];
        }

        private void QuickSort(T[] numbers, int start, int end)
        {
            // Partitions the array into left and right sub-arrays
            // At each step the element that splits the array
            // is at its correct position (the element at position pIndex)
            // Then makes a recursive call to partition the sub-arrays
            // Stops when it gets to sub-arrays of size 0 or 1
            // At that point the array is fully sorted
            // because all elements are at their correct positions
            if (start < end)
            {
                // Randomly select an element called "pivot"
                T pivot = numbers[end]; // in this case the last element

                // Rearrange the array so that all elements smaller than the pivot
                // are to the left of the pivot (not necessarily sorted)
                // and all elements larger than the pivot are to the right
                int pIndex = start;
                for (int i = start; i < end; i++)
                {
                    if (numbers[i].CompareTo(pivot) <= 0)
                    {
                        // swap
                        T temp = numbers[i];
                        numbers[i] = numbers[pIndex];
                        numbers[pIndex] = temp;

                        pIndex++;
                    }
                }

                // final swap to put the pivot at its correct position (pIndex)
                numbers[end] = numbers[pIndex];
                numbers[pIndex] = pivot;

                // Recursive calls for the subarrays left and right of the pivot
                QuickSort(numbers, start, pIndex - 1);
                QuickSort(numbers, pIndex + 1, end);
            }
        }
    }
}
