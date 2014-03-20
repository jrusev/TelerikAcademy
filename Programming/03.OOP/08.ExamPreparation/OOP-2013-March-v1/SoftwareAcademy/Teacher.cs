using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Teacher name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Teacher course cannot be null or empty!");
            }

            this.courses.Add(course);
        }

        public override string ToString()
        {
            // Teacher: Name=(teacher name); Courses=[(course names – comma separated)]
            // If the teacher has no courses added, don’t print them.
            StringBuilder result = new StringBuilder();
            string teacherName = string.Format("Teacher: Name={0};", this.Name);
            result.Append(teacherName);
            if (this.courses.Count > 0)
            {
                result.Append(" Courses=[");
                var courseNames = this.courses.Select(c => c.Name);
                result.Append(string.Join(", ", courseNames));
                result.Append("];");
            }

            result.Length--;
            return result.ToString();
        }
    }
}