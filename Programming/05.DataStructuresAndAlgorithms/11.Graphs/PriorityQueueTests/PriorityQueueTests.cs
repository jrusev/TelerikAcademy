using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

[TestClass]
public class PriorityQueueTests
{
    private readonly int[] items = new[] { 2, 6, 3, 2, 1, 7, 4, 9, 5, 1, 8 };

    [TestMethod]
    public void PriorityQueue_Enqueue()
    {
        var q = new PriorityQueue<int>();
        var minItem = int.MaxValue;

        foreach (var item in items)
        {
            q.Enqueue(item);
            minItem = Math.Min(item, minItem);

            Assert.AreEqual(q.Peek(), minItem);
        }
    }

    [TestMethod]
    public void PriorityQueue_Dequeue()
    {
        var q = new PriorityQueue<int>();
        foreach (var item in items)
        {
            q.Enqueue(item);
        }

        var sortedItems = new List<int>(items);
        sortedItems.Sort();
        foreach (var item in sortedItems)
        {
            Assert.AreEqual(q.Dequeue(), item);
        }
    }
}
