using System;
using System.Collections.Generic;
using System.Diagnostics;

// Implement a class PriorityQueue<T> based on the data structure "binary heap".
class Program
{
    private static void Main()
    {
        var items = new[] { 2, 6, 3, 2, 1, 7, 4, 9, 5, 1, 8 };
        Console.WriteLine("Items: [{0}]", string.Join(", ", items));


        // Priority queue of integers, where a lower number means higher priority
        var queue = new PriorityQueue<int>();        

        // Add each item to the priority queue and 
        // check if the item with the highest priority is at the top of the queue
        var minItem = int.MaxValue;
        foreach (var item in items)
        {
            queue.Enqueue(item);
            minItem = Math.Min(item, minItem);            
            Debug.Assert(queue.Peek() == minItem);
        }

        // Now check if after each dequeue, the items come out ranked by priority
        var sorted = new List<int>();
        while (queue.Count > 0)
        {
            sorted.Add(queue.Dequeue());
        }

        // Items should be sorted in ascending order
        Console.WriteLine("Queue items: [{0}]", string.Join(", ", sorted));
    }
}