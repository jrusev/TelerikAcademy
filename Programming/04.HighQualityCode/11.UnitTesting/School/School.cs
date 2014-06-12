using System;
using System.Collections.Generic;

public class School
{
    private readonly List<Student> students;
    private readonly Student[] studentsById;
    private readonly List<Course> courses;

    public School()
    {
        this.students = new List<Student>();
        this.studentsById = new Student[Student.MaxID - Student.MinID];
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
        for (int i = 0; i < this.studentsById.Length; i++)
        {
            if (this.studentsById[i] != null)
            {
                var id = Student.MinID + i;
                var student = new Student(name, id);

                this.studentsById[i] = student;
                this.students.Add(student);
                return student;
            }
        }

        throw new InvalidOperationException("All available ID numbers are occupied!");
    }

    public Course CreateCourse(string name)
    {
        var course = new Course(name);
        this.courses.Add(course);
        return course;
    }
}