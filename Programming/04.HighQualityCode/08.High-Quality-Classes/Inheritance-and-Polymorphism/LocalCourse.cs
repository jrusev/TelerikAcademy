using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string courseName, string teacherName = null, IList<string> students = null)
            : base(courseName, teacherName, students)
        {
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Length -= 2; // removes the " }" at the end
            if (this.Lab != null)
            {
                result.AppendFormat("; Lab = {0}", this.Lab);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
