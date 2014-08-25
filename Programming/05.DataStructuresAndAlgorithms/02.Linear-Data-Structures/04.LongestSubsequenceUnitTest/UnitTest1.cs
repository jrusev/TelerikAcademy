using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var nums = new List<int>() { 1 };
        var actual = LongestSubsequence.FindLongestSubsequence(nums);
        var expected = new List<int>() { 1 };
        Assert.AreEqual(expected, actual);
    }
}