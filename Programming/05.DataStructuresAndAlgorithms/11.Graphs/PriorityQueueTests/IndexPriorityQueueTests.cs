using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

[TestClass]
public class IndexPriorityQueueTests
{
    private readonly int[] items = new[] { 2, 6, 3, 2, 1, 7, 4, 9, 5, 1, 8 };

    [TestMethod]
    public void IndexMinPQ_Enqueue()
    {
        var q = new IndexPriorityQueue<int>();
        var minItem = int.MaxValue;

        for (int i = 0; i < items.Length; i++)
        {
            // After adding each item, the min item should be on top
            q.Enqueue(i, items[i]);
            minItem = Math.Min(items[i], minItem);

            Assert.IsTrue(q.Contains(i));
            Assert.AreEqual(q.MinKey(), minItem);
        }
    }

    [TestMethod]
    public void IndexMinPQ_Dequeue()
    {
        var q = new IndexPriorityQueue<int>();
        for (int i = 0; i < items.Length; i++)
        {
            q.Enqueue(i, items[i]);
        }

        var sortedItems = new List<int>(items);
        sortedItems.Sort();

        foreach (var item in sortedItems)
        {
            // The top of the queue returns the items in sorted order 
            var minIndex = q.Dequeue();
            Assert.IsFalse(q.Contains(minIndex));
            Assert.AreEqual(items[minIndex], item);
        }
    }

    [TestMethod]
    public void IndexMinPQ_Contains()
    {
        var q = new IndexPriorityQueue<int>();

        Assert.IsFalse(q.Contains(1));

        q.Enqueue(1, 10);
        q.Enqueue(1, 20);
        q.Enqueue(1, 30);

        Assert.IsTrue(q.Contains(1));
        q.Dequeue();
        Assert.IsTrue(q.Contains(1));
        q.Dequeue();
        Assert.IsTrue(q.Contains(1));
        q.Dequeue();
        Assert.IsFalse(q.Contains(1));
    }
}
