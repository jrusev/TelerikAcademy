using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class BinaryHeapTests
{
    private readonly int[] items = new[] { 2, 6, 3, 2, 1, 7, 4, 9, 5, 1, 8 };

    [TestMethod]
    public void Test_InsertItem()
    {
        var heap = new BinaryHeap<int>();
        var minItem = int.MaxValue;

        foreach (var item in items)
        {
            heap.Insert(item);
            minItem = Math.Min(item, minItem);

            Assert.AreEqual(heap.Peek(), minItem);
        }
    }

    [TestMethod]
    public void Test_RemoveRoot()
    {
        var heap = new BinaryHeap<int>();
        foreach (var item in items)
        {
            heap.Insert(item);
        }

        var sortedItems = new List<int>(items);
        sortedItems.Sort();
        foreach (var item in sortedItems)
        {
            Assert.AreEqual(heap.RemoveRoot(), item);
        }
    }
}
