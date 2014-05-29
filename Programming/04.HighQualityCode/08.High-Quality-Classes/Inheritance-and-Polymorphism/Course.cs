namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private readonly IList<string> students;
        private string name;

        public Course(string courseName, string teacherName = null, IList<string> students = null)
        {
            this.Name = courseName;
            this.Teacher = teacherName;
            this.students = students ?? new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public string Teacher { get; set; }

        public void AddStudent(string student)
        {
            if (string.IsNullOrWhiteSpace(student))
            {
                throw new ArgumentException("Student name cannot be null or empty!");
            }

            this.students.Add(student);
        }

        public IList<string> GetStudents()
        {
            return new List<string>(this.students);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.Teacher != null)
            {
                result.AppendFormat("; Teacher = {0}", this.Teacher);
            }

            result.AppendFormat("; Students = {0}", this.StudentsToString());
            return result.ToString();
        }

        private string StudentsToString()
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
    }
}
