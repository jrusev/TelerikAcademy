namespace Sorting.Lib
{
    using System;
    using System.Collections.Generic;

    interface ISortableCollection<T> where T : IComparable<T>
    {
        IList<T> Items { get; }

        bool BinarySearch(T searchItem);

        bool LinearSearch(T searchItem);

        void Shuffle();

        void Sort(ISorter<T> sorter);
    }
}
