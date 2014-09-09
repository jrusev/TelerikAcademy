namespace DataStructures
{
    using System;
    using System.Collections.Generic;

    // I wrote this, it is not fully tested!
    public class IndexPriorityQueue<T> where T : IComparable<T>
    {
        internal struct PNode<P> : IComparable<PNode<P>> where P : IComparable<P>
        {
            public int id;
            public P priority;

            public int CompareTo(PNode<P> other)
            {
                return this.priority.CompareTo(other.priority);
            }
        }

        private readonly List<PNode<T>> items;
        private readonly Dictionary<int, int> register;

        // Creates a new instance of the priority queue (min-heap)
        public IndexPriorityQueue()
        {
            this.items = new List<PNode<T>>();
            register = new Dictionary<int, int>();
        }

        // Get a count of the number of items in the queue.
        public int Count
        {
            get { return this.items.Count; }
        }

        // Removes all items from the queue.
        public void Clear()
        {
            this.items.Clear();
            this.register.Clear();
        }

        public bool Contains(int i)
        {
            int count;
            return register.TryGetValue(i, out count) ? count > 0 : false;
        }

        // Adds an item to the queue.
        public void Enqueue(int index, T priority)
        {
            PNode<T> newItem = new PNode<T>() { id = index, priority = priority };

            int count;
            register[index] = register.TryGetValue(index, out count) ? count + 1 : 1;

            int i = this.Count;
            this.items.Add(newItem);
            // heapify-up
            while (i > 0 && this.items[(i - 1) / 2].CompareTo(newItem) > 0)
            {
                this.items[i] = this.items[(i - 1) / 2];
                i = (i - 1) / 2;
            }

            this.items[i] = newItem;
        }

        // Returns the item at the beginning of the queue without removing it.
        public int MinIndex()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            return this.items[0].id;
        }

        // Returns the item at the beginning of the queue without removing it.
        public T MinKey()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            return this.items[0].priority;
        }

        // Removes and returns the item at the beginning of the queue.
        public int Dequeue()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            var root = this.items[0];

            register[root.id] = Math.Max(0, register[root.id] - 1);

            // Get the last item and bubble it down.
            var tmp = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            if (this.items.Count > 0)
            {
                // heapify-down
                int i = 0;
                while (i < this.items.Count / 2)
                {
                    int j = (2 * i) + 1;
                    if ((j < this.items.Count - 1) && (this.items[j].CompareTo(this.items[j + 1]) > 0))
                    {
                        ++j;
                    }

                    if (this.items[j].CompareTo(tmp) >= 0)
                    {
                        break;
                    }

                    this.items[i] = this.items[j];
                    i = j;
                }

                this.items[i] = tmp;
            }

            return root.id;
        }
    }
}