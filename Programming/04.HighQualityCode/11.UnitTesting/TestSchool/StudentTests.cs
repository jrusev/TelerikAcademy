using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StudentTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_ThrowIfStudentNameIsNull()
    {
        var student = new Student(null, 20000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_ThrowIfStudentNameIsEmpty()
    {
        var student = new Student(" ", 20000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_ThrowIfStudentIDisBelowRange()
    {
        var student = new Student("pesho", 9999);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Test_ThrowIfStudentIDisAboveRange()
    {
        var student = new Student("pesho", 100000);
    }

    [TestMethod]
    public void Test_CreateNewStudentWithCorrectParameters()
    {
        var student = new Student("pesho", 20000);

        Assert.AreEqual("pesho", student.Name);
        Assert.AreEqual(20000, student.Id);
    }
}
