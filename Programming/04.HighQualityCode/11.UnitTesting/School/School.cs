using System;
using System.Collections.Generic;

public class School
{
    private readonly List<Student> students;
    private readonly List<Course> courses;

    public School()
    {
        this.students = new List<Student>();
        this.courses = new List<Course>();
    }

    public IEnumerable<Student> Students
    {
        get
        {
            return this.students;
        }
    }

    public IEnumerable<Course> Courses
    {
        get
        {
            return this.courses;
        }
    }

    public Student RegisterStudent(string name)
    {
        if (this.students.Count > (Student.MaxID - Student.MinID))
        {
            throw new InvalidOperationException("All available ID numbers are occupied!");
        }

        var id = Student.MinID + this.students.Count;
        var student = new Student(name, id);
        this.students.Add(student);
        return student;       
    }

    public void AddCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException("course");
        }

        this.courses.Add(course);
    }

    public bool RemoveCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException("course");
        }

        return this.courses.Remove(course);
    }
}