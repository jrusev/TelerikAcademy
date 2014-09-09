using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

[TestClass]
public class IndexMinPQTests
{
    private readonly int[] items = new[] { 2, 6, 3, 2, 1, 7, 4, 9, 5, 1, 8 };

    [TestMethod]
    public void IndexMinPQ_Enqueue()
    {
        var q = new IndexMinPQ<int>(items.Length);
        var minItem = int.MaxValue;

        for (int i = 0; i < items.Length; i++)
        {
            // After adding each item, the min item should be on top
            q.Insert(i, items[i]);
            minItem = Math.Min(items[i], minItem);

            Assert.AreEqual(q.MinKey(), minItem);
        }
    }

    [TestMethod]
    public void IndexMinPQ_Dequeue()
    {
        var q = new IndexMinPQ<int>(items.Length);
        for (int i = 0; i < items.Length; i++)
        {
            q.Insert(i, items[i]);
        }

        var sortedItems = new List<int>(items);
        sortedItems.Sort();

        foreach (var item in sortedItems)
        {
            // The top of the queue returns the items in sorted order 
            var minIndex = q.DelMin();
            Assert.AreEqual(items[minIndex], item);
        }
    }
}
