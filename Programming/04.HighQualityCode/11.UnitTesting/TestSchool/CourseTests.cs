using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CourseTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_ThrowIfCourseNameIsNull()
    {
        var course = new Course(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_ThrowIfCourseNameIsEmpty()
    {
        var course = new Course("  ");
    }

    [TestMethod]
    public void Test_CreateNewCourseWithCorrectParameters()
    {
        var course = new Course("Unit Testing");

        Assert.AreEqual("Unit Testing", course.Name);
    }

    [TestMethod]
    public void Test_AddStudentToNewCourse()
    {
        var course = new Course("Unit Testing");
        var student = new Student("pesho", 20000);
        course.AddStudent(student);

        Assert.AreEqual(student, course.Students[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_ThrowIfAddingNullStudent()
    {
        var course = new Course("Unit Testing");
        course.AddStudent(null);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_ThrowIfAddingStudentWhenCourseIsFull()
    {
        var course = new Course("Unit Testing");

        for (int i = 0; i < Course.MaxStudents; i++)
            course.AddStudent(new Student("pesho", 20000));

        Assert.AreEqual(Course.MaxStudents, course.Students.Count);

        course.AddStudent(new Student("pesho", 20000));
    }

    [TestMethod]
    public void Test_RemoveStudent()
    {
        var course = new Course("Unit Testing");
        var student = new Student("pesho", 20000);
        course.AddStudent(student);

        Assert.AreEqual(student, course.Students[0]);

        course.RemoveStudent(student);

        Assert.AreEqual(0, course.Students.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_ThrowIfRemovingNullStudent()
    {
        var course = new Course("Unit Testing");
        course.RemoveStudent(null);
    }
}

