namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName, string teacherName = null, IList<string> students = null)
            : base(courseName, teacherName, students)
        {
        }

        public string Town { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = {1}", this.GetType().Name, this.Name);
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.AppendFormat("; Lab = {0}", this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
