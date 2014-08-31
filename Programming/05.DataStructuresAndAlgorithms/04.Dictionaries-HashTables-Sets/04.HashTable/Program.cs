using System;
using System.Linq;

// Implement the data structure "hash table" in a class HashTable<K,T>.
// Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16.
// When the hash table load runs over 75%, perform resizing to 2 times larger capacity.
// Implement the following methods and properties:
//      Add(key, value), Find(key) -> value, Remove( key), Count, Clear(), this[], Keys.
// Try to make the hash table to support iterating over its elements with foreach.
public class Program
{
    public static void Main()
    {
        var topCities = new HashTable<string, double>();

        // Add(key, value)
        topCities.Add("Tokyo", 36.9);
        topCities.Add("Jakarta", 12.8);
        topCities.Add("Seoul", 25.7);
        topCities.Add("Beijing", 23.7);
        topCities.Add("Shanghai", 21.7);

        // foreach
        foreach (var pair in topCities.OrderBy(p => -p.Value))
        {
            Console.WriteLine("{0, -8} -> {1}", pair.Key, pair.Value);
        }

        // Add already existing key
        try
        {
            topCities.Add("Jakarta", 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        // Keys
        Console.WriteLine("Keys: {0}", string.Join(", ", topCities.Keys));

        // Count
        Console.WriteLine("Number of key-value pairs: {0}", topCities.Count);

        // Find(key)
        topCities.PrintValue("Tokyo");
        Console.WriteLine("Jakarta -> {0}", topCities.Find("Jakarta"));

        // this[key]
        Console.WriteLine("Beijing -> {0}", topCities["Beijing"]);

        // ContainsKey(key)
        Console.WriteLine("Hash table contains 'Delhi': {0}", topCities.ContainsKey("Delhi"));

        // Remove(key)
        topCities.Remove("Seoul");
        Console.WriteLine("Remove 'Seoul'");
        Console.WriteLine("Keys: {0}", string.Join(", ", topCities.Keys));
        Console.WriteLine("Number of key-value pairs: {0}", topCities.Count);

        // Remove non-existing
        Console.WriteLine("Removing 'Sofia' -> {0}", topCities.Remove("Sofia"));

        // Clear
        topCities.Clear();
        Console.WriteLine("Clear hash table");
        Console.WriteLine("Number of key-value pairs: {0}", topCities.Count);
    }
}
