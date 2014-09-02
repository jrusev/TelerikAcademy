using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;

// A class that allows adding triples {key1, key2, value} and fast search by key1, key2 or by both key1 and key2.
public class BiDictionary<K1, K2, T> : IEnumerable<Tuple<K1, K2, ICollection<T>>>
{
    private const bool AllowDuplicates = true;
    private readonly MultiDictionary<K1, T> dictByKey1 = new MultiDictionary<K1, T>(AllowDuplicates);
    private readonly MultiDictionary<K2, T> dictByKey2 = new MultiDictionary<K2, T>(AllowDuplicates);

    // This dictionary allows hashing by both key1 and key2, represented as a Tuple<K1, K2>
    private readonly MultiDictionary<Tuple<K1, K2>, T> dictByBoth = new MultiDictionary<Tuple<K1, K2>, T>(AllowDuplicates);

    public IEnumerable<T> GetByK1(K1 key) { return this.dictByKey1[key]; }

    public IEnumerable<T> GetByK2(K2 key) { return this.dictByKey2[key]; }

    public IEnumerable<T> GetByBoth(K1 key1, K2 key2) { return this.dictByBoth[Tuple.Create(key1, key2)]; }

    public void Add(K1 key1, K2 key2, T value)
    {
        this.dictByKey1.Add(key1, value);
        this.dictByKey2.Add(key2, value);
        this.dictByBoth.Add(Tuple.Create(key1, key2), value);
    }

    public IEnumerator<Tuple<K1, K2, ICollection<T>>> GetEnumerator()
    {
        foreach (var kvp in this.dictByBoth)
            yield return Tuple.Create(kvp.Key.Item1, kvp.Key.Item2, kvp.Value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}