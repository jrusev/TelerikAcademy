using System;
using System.Collections;
using System.Collections.Generic;

// Implement the ADT stack as auto-resizable array.
// Resize the capacity on demand (when no space is available to add / insert a new element).
public class ArrayStack<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;
    private T[] items;

    // Initializes a new instance of the Stack<T> class that is empty and has the default initial capacity.
    public ArrayStack()
    {
        this.Clear();
    }

    // Gets the number of items contained in the Stack<T>.
    public int Count { get; private set; }

    // The total number of items the stack can hold without resizing
    public int Capacity
    {
        get
        {
            return this.items.Length;
        }
    }

    // Inserts an object at the top of the Stack<T>.
    public void Push(T item)
    {
        this.AutoResize();
        this.items[this.Count] = item;
        this.Count++;
    }

    // Removes and returns the object at the top of the Stack<T>.
    public T Pop()
    {
        var popItem = this.Peek();
        this.items[this.Count - 1] = default(T);
        this.Count--;
        return popItem;
    }

    // Returns the object at the top of the Stack<T> without removing it.
    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new ApplicationException("The stack is empty!");
        }

        return this.items[this.Count - 1];
    }

    // Removes all objects from the Stack<T>.
    public void Clear()
    {
        this.items = new T[DefaultCapacity];
        this.Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(" -> ", this);
    }

    // Resizes the internal array when when there is no space to add a new element.
    private void AutoResize()
    {
        if (this.Count == this.Capacity)
        {
            var newItems = new T[this.Capacity * 2];
            Array.Copy(this.items, newItems, this.items.Length);
            this.items = newItems;
        }
    }
}
