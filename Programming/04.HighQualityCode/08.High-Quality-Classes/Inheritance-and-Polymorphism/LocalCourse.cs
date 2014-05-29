namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string courseName, string teacherName = null, IList<string> students = null)
            : base(courseName, teacherName, students)
        {
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = {1}", this.GetType().Name, this.Name);
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.AppendFormat("; Lab = {0}", this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
