namespace Sorting.Lib
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            this.SelectionSort(arr);
        }

        private void SelectionSort(IList<T> arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        min = j;
                    }
                }

                T temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
    }
}
