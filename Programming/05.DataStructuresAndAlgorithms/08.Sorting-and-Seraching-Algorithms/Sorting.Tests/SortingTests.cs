using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting.Lib;

[TestClass]
public class SortingTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_SelectionNull()
    {
        new SelectionSorter<int>().Sort(null);
    }

    [TestMethod]
    public void Test_Selection0()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 0);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());        
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_Selection1()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_SelectionRandom1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1000);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_SelectionSorted1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Sorted, 1000);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_SelectionReversed1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Reversed, 1000);
        var list = array.ToList();

        new SelectionSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_QuickNull()
    {
        new QuickSorter<int>().Sort(null);
    }

    [TestMethod]
    public void Test_Quick0()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 0);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_Quick1()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_QuickRandom1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1000);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_QuickSorted1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Sorted, 1000);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_QuickReversed1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Reversed, 1000);
        var list = array.ToList();

        new QuickSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_MergeNull()
    {
        new MergeSorter<int>().Sort(null);
    }

    [TestMethod]
    public void Test_Merge0()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 0);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_Merge1()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_MergeRandom1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Random, 1000);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_MergeSorted1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Sorted, 1000);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }

    [TestMethod]
    public void Test_MergeReversed1000()
    {
        var array = TestHelpers.GenerateIntArray(ArrayOptions.Reversed, 1000);
        var list = array.ToList();

        new MergeSorter<int>().Sort(list);

        Assert.IsTrue(list.IsSorted());
        Assert.IsTrue(list.SameContents(array));
    }
}
