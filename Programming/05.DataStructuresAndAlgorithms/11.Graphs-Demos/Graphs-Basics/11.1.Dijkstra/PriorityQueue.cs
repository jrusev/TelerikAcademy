using System;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T>
{
    private readonly List<T> items;

    // Creates a new instance of the priority queue with the default comparer (min-heap)
    public PriorityQueue()
    {
        this.items = new List<T>();
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
    }

    // Adds an item to the queue.
    public void Enqueue(T newItem)
    {
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
    public T Peek()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("The heap is empty.");
        }

        return this.items[0];
    }

    // Removes and returns the item at the beginning of the queue.
    public T Dequeue()
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

        return root;
    }
}