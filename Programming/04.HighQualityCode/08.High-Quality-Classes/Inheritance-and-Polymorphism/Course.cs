using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        private readonly List<string> students;

        public Course(string courseName, string teacherName = null, IList<string> students = null)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>();
            if (students != null)
            {
                this.students.AddRange(students);
            }
        }

        public string Name { get; private set; }

        public string TeacherName { get; set; }

        public void AddStudent(string student)
        {
            this.students.Add(student);
        }

        public IList<string> GetStudents()
        {
            return new List<string>(this.students);
        }

        private string GetStudentsAsString()
        {
            if (this.students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = {1}", this.GetType().Name, this.Name);
            if (this.TeacherName != null)
            {
                result.AppendFormat("; Teacher = {0}", this.TeacherName);
            }
            result.AppendFormat("; Students = {0}", this.GetStudentsAsString());
            result.Append(" }");
            return result.ToString();
        }
    }
}
