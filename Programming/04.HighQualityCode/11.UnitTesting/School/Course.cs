using System;
using System.Collections.Generic;

public class Course
{
    public const int MaxStudents = 30;

    private readonly IList<Student> students;

    public Course(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name must be not be null or empty!");
        }

        this.Name = name;
        this.students = new List<Student>();
    }

    public string Name { get; private set; }

    public IList<Student> Students
    {
        get
        { 
            return this.students;
        }
    }

    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("student");
        }

        if (this.students.Count >= MaxStudents)
        {
            throw new InvalidOperationException("Course is full!");
        }

        this.students.Add(student);
    }

    public bool RemoveStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("student");
        }

        return this.students.Remove(student);
    }
}