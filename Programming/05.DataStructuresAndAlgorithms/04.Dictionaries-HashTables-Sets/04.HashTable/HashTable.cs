using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// A hash table implemented with array of LinkedList<KeyValuePair<K,T>>
public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private const int InitialCapacity = 4; // use '4' to test the resizing operation
    private const float MaxLoad = 0.75f;
    private const int ResizeFactor = 2;

    private LinkedList<KeyValuePair<TKey, TValue>>[] table;

    // Initializes a new instance of the HashTable<K, T> class that is empty.
    public HashTable()
    {
        this.Clear();
    }

    // Gets the number of key-value pairs contained in the hash table.
    public int Count { get; private set; }

    // Gets a collection containing the keys in the hash table.
    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.table.Where(x => x != null).SelectMany(x => x).Select(x => x.Key);
        }
    }

    // Gets or sets a value corresponding to a given key
    public TValue this[TKey key]
    {
        get
        {
            return this.Find(key);
        }

        set
        {
            this.Add(key, value);
        }
    }

    // Removes all keys and values from the hash table.
    public void Clear()
    {
        this.table = new LinkedList<KeyValuePair<TKey, TValue>>[InitialCapacity];
        this.Count = 0;
    }

    // Adds the specified key and value to the hash table.
    public void Add(TKey key, TValue value)
    {
        if (this.ContainsKey(key))
        {
            throw new ArgumentException("An element with the same key already exists in the hash table!");
        }

        if (this.Count >= MaxLoad * this.table.Length)
        {
            this.ResizeTable();
        }

        var pair = new KeyValuePair<TKey, TValue>(key, value);

        int index = this.GetKeyIndex(key, this.table.Length);

        if (this.table[index] == null)
        {
            this.table[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
        }

        this.table[index].AddLast(pair);
        this.Count++;
    }

    // Gets the value associated with the specified key or throws an exception if not found.
    public TValue Find(TKey key)
    {
        int index = this.GetKeyIndex(key, this.table.Length);

        if (this.table[index] == null)
        {
            throw new KeyNotFoundException("Specified key not found!");
        }

        var chain = this.table[index];
        foreach (var pair in chain)
        {
            if (pair.Key.Equals(key))
            {
                return pair.Value;
            }
        }

        throw new KeyNotFoundException("Specified key not found!");
    }

    // Removes the values with the specified key from the hash table.
    public bool Remove(TKey key)
    {
        int index = this.GetKeyIndex(key, this.table.Length);

        if (this.table[index] == null)
        {
            // Key does not exist in the hash table.
            return false;
        }

        var chain = this.table[index];
        var pairsToRemove = this.table[index].Where(p => p.Key.Equals(key)).ToList();

        if (pairsToRemove.Count == 0)
        {
            // No values found that correspond to the given key
            return false;
        }

        foreach (var pair in pairsToRemove)
        {
            chain.Remove(pair);
            this.Count--;
        }

        return true;
    }

    // Determines whether the hash table contains the specified key.
    public bool ContainsKey(TKey key)
    {
        int index = this.GetKeyIndex(key, this.table.Length);

        if (this.table[index] == null)
        {
            return false;
        }

        var chain = this.table[index];
        foreach (var pair in chain)
        {
            if (pair.Key.Equals(key))
            {
                return true;
            }
        }

        return false;
    }

    // Prints a key and its associated value
    public void PrintValue(TKey key)
    {
        Console.WriteLine("{0} -> {1}", key, this[key]);
    }

    // Iterates through the key-value pairs in the hash table
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        foreach (var chain in this.table)
        {
            if (chain != null)
            {
                foreach (var pair in chain)
                {
                    yield return pair;
                }
            }
        }
    }

    // Iterates through the key-value pairs in the hash table
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    // Gets the index that corresponds to the given key and table length 
    private int GetKeyIndex(TKey key, int length)
    {
        int index = key.GetHashCode();
        index = index & 0x7FFFFFFF; // clear the negative bit
        index = index % length;
        return index;
    }

    // Resizes the table
    private void ResizeTable()
    {
        var newTable = new LinkedList<KeyValuePair<TKey, TValue>>[this.table.Length * ResizeFactor];
        int newCount = 0;
        foreach (var chain in this.table)
        {
            if (chain == null)
            {
                continue;
            }

            foreach (var pair in chain)
            {
                var key = pair.Key;
                int index = this.GetKeyIndex(key, newTable.Length);
                if (newTable[index] == null)
                {
                    newTable[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                }

                newTable[index].AddLast(pair);
                newCount++;
            }
        }

        this.table = newTable;
        this.Count = newCount;
    }
}
