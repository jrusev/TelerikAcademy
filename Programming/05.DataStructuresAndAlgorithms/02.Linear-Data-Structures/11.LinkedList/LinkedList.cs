using System;
using System.Collections;
using System.Collections.Generic;

// Define a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
public class LinkedList<T> : IEnumerable<T>
{
    /// <summary>
    /// Initializes a new instance of the LinkedList<T> class that is empty.
    /// </summary>
    public LinkedList()
    {
        this.FirstElement = null;
        this.LastElement = null;
        this.Count = 0;
    }

    /// <summary>
    /// Gets the first node of the LinkedList<T>.
    /// </summary>
    public ListItem<T> FirstElement { get; private set; }

    /// <summary>
    /// Gets the last node of the LinkedList<T>.
    /// </summary>
    public ListItem<T> LastElement { get; private set; }

    /// <summary>
    /// Gets the number of nodes actually contained in the LinkedList<T>.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Adds a new node containing the specified value at the start of the LinkedList<T>.
    /// </summary>
    /// <param name="value">The value to add at the start of the LinkedList<T>.</param>
    /// <returns>The new ListItem<T> containing value.</returns>
    public ListItem<T> AddFirst(T value)
    {
        var newItem = new ListItem<T>(value);

        if (this.FirstElement == null)
        {
            this.LastElement = newItem;
        }
        else
        {
            newItem.NextItem = this.FirstElement;
        }

        this.FirstElement = newItem;
        this.Count++;
        return newItem;
    }

    /// <summary>
    /// Adds a new node containing the specified value at the end of the LinkedList<T>.
    /// </summary>
    /// <param name="value">The value to add at the end of the LinkedList<T>.</param>
    /// <returns>The new ListItem<T> containing value.</returns>
    public ListItem<T> AddLast(T value)
    {
        var newItem = new ListItem<T>(value);

        if (this.FirstElement == null)
        {
            this.FirstElement = newItem;
        }
        else
        {
            this.LastElement.NextItem = newItem;
        }

        this.LastElement = newItem;
        this.Count++;
        return newItem;
    }

    /// <summary>
    /// Removes all nodes from the LinkedList<T>.
    /// </summary>
    public void Clear()
    {
        // Garbage collection will clear out all the linked list nodes after we remove the head and tail reference.
        this.FirstElement = null;
        this.LastElement = null;
        this.Count = 0;
    }

    /// <summary>
    /// Determines whether a value is in the LinkedList<T>.
    /// </summary>
    /// <param name="value">The value to locate in the LinkedList<T>.</param>
    /// <returns>true if value is found; otherwise, false.</returns>
    public bool Contains(T value)
    {
        if (this.Find(value) != null)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Finds the first node that contains the specified value.
    /// </summary>
    /// <param name="value">The value to locate in the LinkedList<T>.</param>
    /// <returns>The first ListItem<T> that contains the specified value, if found; otherwise, null.</returns>
    public ListItem<T> Find(T value)
    {
        var node = this.FirstElement;
        while (node != null)
        {
            if (object.Equals(node.Value, value))
            {
                return node;
            }

            node = node.NextItem;
        }

        return null;
    }

    /// <summary>
    /// Removes the first occurrence of the specified value from the LinkedList<T>.
    /// </summary>
    /// <param name="value">The value to remove from the LinkedList<T>.</param>
    /// <returns>true if the element containing value is successfully removed; otherwise, false.</returns>
    public bool Remove(T value)
    {
        // Find the element containing the searched item
        ListItem<T> currentNode = this.FirstElement;
        ListItem<T> prevNode = null;
        while (currentNode != null)
        {
            if (object.Equals(currentNode.Value, value))
            {
                break;
            }

            prevNode = currentNode;
            currentNode = currentNode.NextItem;
        }

        if (currentNode == null)
        {
            // The element is not found in the list
            return false;
        }
        else
        {
            // The element is found in the list -> remove it
            this.Count--;

            if (this.Count == 0)
            {
                // The list becomes empty -> remove head and tail
                this.FirstElement = null;
                this.LastElement = null;
            }
            else if (prevNode == null)
            {
                // The head node was removed --> update the head
                this.FirstElement = currentNode.NextItem;
            }
            else
            {
                // Redirect the pointers to skip the removed node
                prevNode.NextItem = currentNode.NextItem;
            }

            // Fix the tail in case it was removed
            if (object.ReferenceEquals(this.LastElement, currentNode))
            {
                this.LastElement = prevNode;
            }

            return true;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        for (var current = this.FirstElement; current != null; current = current.NextItem)
        {
            yield return current.Value;
        }            
    }

    /// <summary>
    /// Returns an enumerator that iterates through the linked list as a collection.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}