using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class NumberInArrayUnitTest
{
    // A test program to check if the CountOccurence method in problem 4 is working correctly.
    // To run the program right-click anywhere in the Text Editor window and click "Run Tests".
    // Note: If you click inside a TestMethod declaration only that test will run.
    // Check the result in the Test Explorer window.
    // For an explanation see here:
    // http://www.youtube.com/watch?feature=player_detailpage&v=nzbh8o8tqJw#t=6993
 
    [TestMethod]
    public void TestMultipleOccurences()
    {
        // Tests for a nunmber that appears more than once.
        int[] numbers = { 2, 3, 5, 5, 6, 6, 7, 4, 3, 5, 8, 9, 4, 7, 4, 6, 3 };
        int result = NumberInArray.CountOccurence(numbers, 5);
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void TestOneOccurence()
    {
        // Tests for a nunmber that appears once.
        int[] numbers = { 2, 3, 5, 5, 6, 6, 7, 4, 3, 5, 8, 9, 4, 7, 4, 6, 3 };
        int result = NumberInArray.CountOccurence(numbers, 9);
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void TestNoOccurence()
    {
        // Tests for a nunmber that is not found in the array.
        int[] numbers = { 2, 3, 5, 5, 6, 6, 7, 4, 3, 5, 8, 9, 4, 7, 4, 6, 3 };
        int result = NumberInArray.CountOccurence(numbers, 10);
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void TestEmptyArray()
    {
        // Tests with an empty array (should return 0).
        int[] numbers = { };
        int result = NumberInArray.CountOccurence(numbers, 10);
        Assert.AreEqual(0, result);
    }
}