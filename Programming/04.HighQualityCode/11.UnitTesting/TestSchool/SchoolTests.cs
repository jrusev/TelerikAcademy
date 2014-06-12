using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SchoolTests
{
    [TestMethod]
    public void Test_NewSchoolReturnsStudentListWhichIsNotNull()
    {
        var school = new School();
        Assert.IsNotNull(school.Students);
    }

    [TestMethod]
    public void Test_NewSchoolReturnsCourseListWhichIsNotNull()
    {
        var school = new School();
        Assert.IsNotNull(school.Courses);
    }

    [TestMethod]
    public void Test_RegisterStudentReturnsCorrectStudent()
    {
        var school = new School();
        var student = school.RegisterStudent("pesho");

        Assert.AreEqual("pesho", student.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_RegisterStudentAfterAllIDsAreUsed()
    {
        var school = new School();
        var maxNumberOfIds = Student.MaxID - Student.MinID;

        for (int i = 0; i <= maxNumberOfIds; i++)
        {
            school.RegisterStudent("pesho");
        }

        var lastStudent = school.Students[school.Students.Count - 1];

        Assert.AreEqual(Student.MaxID, lastStudent.Id);

        school.RegisterStudent("pesho");
    }

    [TestMethod]
    public void Test_AddCourseWithValidData()
    {
        var school = new School();
        var course = new Course("Unit Testing");
        school.AddCourse(course);

        Assert.AreEqual(course, school.Courses[0]);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_ThrowIfAddingNullCourse()
    {
        var school = new School();
        school.AddCourse(null);
    }

    [TestMethod]
    public void Test_AddAndRemoveCourse()
    {
        var school = new School();
        var course = new Course("Unit Testing");
        school.AddCourse(course);

        Assert.AreEqual(course, school.Courses[0]);

        school.RemoveCourse(course);

        Assert.AreEqual(0, school.Courses.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Test_ThrowIfRemovingNullCourse()
    {
        var school = new School();
        school.RemoveCourse(null);
    }
}
