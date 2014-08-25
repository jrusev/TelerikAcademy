using System;
using System.Collections;
using System.Collections.Generic;

// Implement the ADT queue as dynamic linked list.
// Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
public class LinkedQueue<T> : IEnumerable<T>
{
    private QueueNode<T> beginning;
    private QueueNode<T> end;

    // Initializes a new instance of the LinkedQueue<T> class that is empty.
    public LinkedQueue()
    {
        this.Clear();
    }

    // Gets the number of elements contained in the LinkedQueue<T>.
    public int Count { get; private set; }

    // Removes all objects from the LinkedQueue<T>.
    public void Clear()
    {
        this.beginning = null;
        this.end = null;
        this.Count = 0;
    }

    // Removes and returns the object at the beginning of the LinkedQueue<T>.
    public T Dequeue()
    {
        if (this.beginning == null)
        {
            throw new InvalidOperationException("The queue is empty!");
        }

        var result = this.beginning.Value;
        this.beginning = this.beginning.Next;

        // If the new beginning is not empty, we break the link to the original beginning.
        if (this.beginning != null)
        {
            this.beginning.Previous = null;
        }

        this.Count--;
        return result;
    }

    // Adds an object to the end of the LinkedQueue<T>.
    public void Enqueue(T item)
    {
        var node = new QueueNode<T>(item);        

        if (this.end != null)
        {
            this.end.Next = node;
            node.Previous = this.end;
            this.end = node;         
        }
        else
        {
            this.beginning = this.end = node;
        }

        this.Count++;
    }

    // Returns the object at the beginning of the LinkedQueue<T> without removing it.
    public T Peek()
    {
        if (this.beginning == null)
        {
            throw new InvalidOperationException("The queue is empty!");
        }

        return this.beginning.Value;
    }

    // Returns an enumerator that iterates through the LinkedQueue<T>.
    public IEnumerator<T> GetEnumerator()
    {
        var node = this.beginning;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }

        ////for (var current = this.FirstElement; current != null; current = current.NextItem)
        ////{
        ////    yield return current.Value;
        ////}  
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    // Returns a string with all elements in the LinkedQueue<T>.
    public override string ToString()
    {
        return string.Join("<-", this);
    }

    // An internal class to hold the elements of the queue.
    private class QueueNode<T>
    {
        // Initializes a new instance of the QueueNode<T> class with the specified value.
        public QueueNode(T value)
        {
            this.Value = value;
            this.Next = null;
            this.Previous = null;
        }

        public QueueNode<T> Next { get; set; }

        public QueueNode<T> Previous { get; set; }

        public T Value { get; private set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
