using System;
using System.Collections.Generic;

public class BinaryHeap<T>
{
    private readonly IComparer<T> comparer;
    private readonly List<T> items = new List<T>();

    // Creates a new instance of the binary heap with the default comparer (min-heap)
    public BinaryHeap()
        : this(Comparer<T>.Default)
    {
    }

    // Creates a new instance of the binary heap with the specified comparer
    public BinaryHeap(IComparer<T> comp)
    {
        this.comparer = comp;
    }

    // Get a count of the number of items in the heap.
    public int Count
    {
        get { return this.items.Count; }
    }

    // Removes all items from the heap.
    public void Clear()
    {
        this.items.Clear();
    }

    // Inserts an item onto the heap.
    public void Insert(T newItem)
    {
        int i = this.Count;
        this.items.Add(newItem);
        // heapify-up
        while (i > 0 && this.comparer.Compare(this.items[(i - 1) / 2], newItem) > 0)
        {
            this.items[i] = this.items[(i - 1) / 2];
            i = (i - 1) / 2;
        }

        this.items[i] = newItem;
    }

    // Return the root item from the heap, without removing it.
    public T Peek()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("The heap is empty.");
        }

        return this.items[0];
    }

    // Removes and returns the root item from the heap.
    public T RemoveRoot()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("The heap is empty.");
        }

        T root = this.items[0];

        // Get the last item and bubble it down.
        T tmp = this.items[this.items.Count - 1];
        this.items.RemoveAt(this.items.Count - 1);
        if (this.items.Count > 0)
        {
            // heapify-down
            int i = 0;
            while (i < this.items.Count / 2)
            {
                int j = (2 * i) + 1;
                if ((j < this.items.Count - 1) && (this.comparer.Compare(this.items[j], this.items[j + 1]) > 0))
                {
                    ++j;
                }

                if (this.comparer.Compare(this.items[j], tmp) >= 0)
                {
                    break;
                }

                this.items[i] = this.items[j];
                i = j;
            }

            this.items[i] = tmp;
        }

        return root;
    }
}