namespace GenericList
{
    using System;

    // Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    // Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    // Implement methods for:
    //      adding element, accessing element by index, removing element by index,
    //      inserting element at given position, clearing the list,
    //      finding element by its value and ToString().
    // Check all input parameters to avoid accessing elements at invalid positions.
    // Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
    // Create generic methods for finding the minimal and maximal element in the GenericList<T>.
    public class GenericList<T>
        where T : IComparable<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int count;

        public GenericList(int capacity = DefaultCapacity)
        {
            if (capacity <= 0)
            {
                throw new ApplicationException("Capacity cannot be negative!");
            }

            this.items = new T[capacity];
            this.count = 0;
        }

        public GenericList(params T[] array)
        {
            this.items = new T[array.Length];
            this.count = array.Length;
            Array.Copy(array, this.items, array.Length);
        }

        // Number of elements actually contained in the list
        public int Count
        {
            get { return this.count; }
        }

        // The total number of elements the list can hold without resizing
        public int Capacity
        {
            get { return this.items.Length; }
        }

        // Access element by index
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException("Index out of range!");
                }

                return this.items[index];
            }

            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException("Index out of range!");
                }

                this.items[index] = value;
            }
        }

        // Add element
        public void Add(T item)
        {
            this.AdjustCapacity();
            this.items[this.count] = item;
            this.count++;
        }

        // Removing element by index
        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }

            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default(T);
            this.count--;
        }

        // Insert element at given position
        public void InsertAt(T item, int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }

            this.AdjustCapacity();
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i + 1] = this.items[i];
            }

            this.items[index] = item;
            this.count++;
        }

        // Clear the list
        public void Clear()
        {
            if (this.count == 0)
            {
                return; // nothing to clear
            }

            this.items = new T[DefaultCapacity];
            this.count = 0;
        }

        // Find element by its value, return -1 if not found
        public int Find(T value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        // Find Min value in the list
        public T Min()
        {
            if (this.Count == 0)
            {
                throw new ApplicationException("Searching min value in an empty list!");
            }

            if (this.Count == 1)
            {
                return this.items[0];
            }

            T min = this.items[0];
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].CompareTo(min) < 0)
                {
                    min = this.items[i];
                }
            }

            return min;
        }

        // Find Max value in the list
        public T Max()
        {
            if (this.Count == 0)
            {
                throw new ApplicationException("Searching max value in an empty list!");
            }

            if (this.Count == 1)
            {
                return this.items[0];
            }

            T max = this.items[0];
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].CompareTo(max) > 0)
                {
                    max = this.items[i];
                }
            }

            return max;
        }

        // Override ToString
        public override string ToString()
        {
            return string.Join(", ", this.items);
        }

        // Auto-resize functionality
        private void AdjustCapacity()
        {
            if (this.Count == this.Capacity)
            {
                T[] itemsNew = new T[this.Capacity * 2];
                Array.Copy(this.items, itemsNew, this.items.Length);
                this.items = itemsNew;
            }
        }
    }
}