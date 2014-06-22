using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MatrixRotatingWalkTest
{
    [TestMethod]
    public void Test_FillMatrix_6x6()
    {
        var filledMatrix = MatrixRotatingWalk.FillMatrix(6);

        var expected = new int[,]
        {
            {1,16,17,18,19,20},
            {15,2,27,28,29,21},
            {14,31,3,26,30,22},
            {13,36,32,4,25,23},
            {12,35,34,33,5,24},
            {11,10,9,8,7,6}
        };

        for (int row = 0; row < 6; ++row)
        {
            for (int col = 0; col < 6; col++)
            {
                Assert.AreEqual(filledMatrix[row, col], expected[row, col]);
            }
        }
    }
}
