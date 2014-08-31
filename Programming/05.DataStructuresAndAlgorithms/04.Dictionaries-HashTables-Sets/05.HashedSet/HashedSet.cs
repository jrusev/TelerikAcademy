using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Represents a set, implemented with HashTable<K,bool>
public class HashedSet<T> : IEnumerable<T>
{
    // We will use a hash table to hold the keys, and use bool for the values to save memory.
    private HashTable<T, bool> set;

    // Initializes a new instance of the HashedSet<T> class that is empty.
    public HashedSet()
    {
        this.set = new HashTable<T, bool>();
    }

    // Initializes a new instance of the HashedSet<T> class that contains elements copied from the specified collection.
    public HashedSet(IEnumerable<T> collection)
    {
        this.set = new HashTable<T, bool>();
        foreach (var item in collection)
        {
            this.Add(item);
        }
    }

    // Gets the number of elements that are contained in a set.
    public int Count
    {
        get { return this.set.Count; }
    }

    // Adds the specified element to a set.
    // Returns true if the element is added to the set; false if the element is already present.
    public bool Add(T item)
    {
        if (this.set.ContainsKey(item))
        {
            return false;
        }

        this.set.Add(item, false);
        return true;
    }

    // Determines whether the set contains the specified element.
    public bool Find(T item)
    {
        return this.set.ContainsKey(item);
    }

    // Removes the specified element from the set.
    public bool Remove(T item)
    {
        return this.set.Remove(item);
    }

    // Removes all elements from the set.
    public void Clear()
    {
        this.set = new HashTable<T, bool>();
    }

    // Modifies the current HashedSet<T> object to contain all elements that are present in itself, the specified collection, or both.
    public void Union(IEnumerable<T> otherCollection)
    {
        foreach (var item in otherCollection)
        {
            this.Add(item);
        }
    }

    // Modifies the current HashedSet<T> object to contain only the elements that are present in both collections.
    public void Intersect(IEnumerable<T> otherCollection)
    {
        foreach (var item in this.set.Keys.ToList())
        {
            if (!otherCollection.Contains(item))
            {
                this.Remove(item);
            }
        }
    }

    public override string ToString()
    {
        return '[' + string.Join(", ", this.set.Select(item => item.Key)) + ']';
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.set.Select(kvp => kvp.Key).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
