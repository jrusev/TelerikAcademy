using System;
using System.Collections.Generic;

public class School
{
    private readonly Dictionary<int, Student> idToStudent = new Dictionary<int, Student>();
    private readonly List<Student> students = new List<Student>();
    private readonly List<Course> courses = new List<Course>();

    public School()
    {
    }

    public int StudentCount { get { return this.students.Count; } }

    public int CourseCount { get { return this.courses.Count; } }

    public IEnumerable<Student> Students { get { return this.students; } }

    public IEnumerable<Course> Courses { get { return this.courses; } }

    public Student CreateStudent(string name)
    {
        for (int id = Student.MinID; id <= Student.MaxID; ++id)
        {
            if (!this.idToStudent.ContainsKey(id))
            {
                return this.CreateStudentInner(name, id);
            }
        }

        throw new InvalidOperationException("No valid ID numbers left unassigned!");
    }

    public Student CreateStudent(string name, int id)
    {
        if (this.idToStudent.ContainsKey(id))
        {
            throw new ArgumentException("Student id must be unique!");
        }

        return this.CreateStudentInner(name, id);
    }

    public Course CreateCourse(string name)
    {
        var ret = new Course(name);
        this.courses.Add(ret);
        return ret;
    }

    public bool StudentExists(int id)
    {
        return this.idToStudent.ContainsKey(id);
    }

    private Student CreateStudentInner(string name, int id)
    {
        var ret = new Student(name, id);
        this.idToStudent[id] = ret;
        this.students.Add(ret);
        return ret;
    }
}