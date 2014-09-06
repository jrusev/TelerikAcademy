namespace Sorting.Lib
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> : ISortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private readonly Random rand = new Random();

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        // time: O(n), space: O(1)
        public bool LinearSearch(T searchItem)
        {
            if (searchItem == null)
            {
                throw new ArgumentNullException("item");
            }

            foreach (var item in this.items)
            {
                if (searchItem.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        // time: O(log n), space: O(1)
        public bool BinarySearch(T searchItem)
        {
            if (searchItem == null)
            {
                throw new ArgumentNullException("item");
            }

            int left = 0;
            int right = this.Items.Count;           

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (this.items[mid].CompareTo(searchItem) < 0)
                {
                    left = mid + 1;
                }
                else if (this.items[mid].CompareTo(searchItem) > 0)
                {
                    right = mid - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            this.Shuffle(this.items);
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private void Shuffle(IList<T> array)
        {
            var random = this.rand;
            for (int i = array.Count; i > 1; i--)
            {
                int j = random.Next(i);
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
        }
    }
}
