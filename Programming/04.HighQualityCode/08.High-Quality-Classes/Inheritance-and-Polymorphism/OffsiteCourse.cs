using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public string Town { get; set; }

        public OffsiteCourse(string courseName, string teacherName = null, IList<string> students = null)
            : base(courseName, teacherName, students)
        {
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Length -= 2; // removes the " }" at the end
            if (this.Town != null)
            {
                result.AppendFormat("; Lab = {0}", this.Town);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
