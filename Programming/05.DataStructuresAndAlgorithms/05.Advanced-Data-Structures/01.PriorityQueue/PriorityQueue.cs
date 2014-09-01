using System.Collections.Generic;

public class PriorityQueue<T>
{
    private readonly BinaryHeap<T> heap;

    // Creates a new instance of the priority queue with the default comparer (min-heap)
    public PriorityQueue()
        : this(Comparer<T>.Default)
    {
    }

    // Creates a new instance of the priority queue with the specified comparer
    public PriorityQueue(IComparer<T> comp)
    {
        this.heap = new BinaryHeap<T>(comp);
    }

    // Get a count of the number of items in the queue.
    public int Count
    {
        get { return this.heap.Count; }
    }

    // Removes all items from the queue.
    public void Clear()
    {
        this.heap.Clear();
    }

    // Adds an item to the queue.
    public void Enqueue(T newItem)
    {
        this.heap.Insert(newItem);
    }

    // Returns the item at the beginning of the queue without removing it.
    public T Peek()
    {
        return this.heap.Peek();
    }

    // Removes and returns the item at the beginning of the queue.
    public T Dequeue()
    {
        return this.heap.RemoveRoot();   
    }
}