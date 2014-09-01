using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class PriorityQueueTests
{
    private readonly List<int> items = new List<int>() { 2, 6, 3, 2, 1, 7, 4, 9, 5, 1, 8 };

    [TestMethod]
    public void Test_Enqueue()
    {
        var pq = new PriorityQueue<int>();
        var minItem = int.MaxValue;

        foreach (var item in items)
        {
            pq.Enqueue(item);
            minItem = Math.Min(item, minItem);
            Assert.AreEqual(pq.Peek(), minItem);
        }
    }

    [TestMethod]
    public void Test_Dequeue()
    {
        var pq = new PriorityQueue<int>();
        items.ForEach(item => pq.Enqueue(item));

        items.OrderBy(x => x).ToList().ForEach(item => Assert.AreEqual(pq.Dequeue(), item));
    }
}
