using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Course : ICourse
    {
        private IList<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        public string Name { get; set; }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        // (course type): Name=(course name); Teacher=(teacher name);
        // Topics=[(course topics – comma separated)];
        // Lab=(lab name – when applicable); Town=(town name – when applicable);
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string courseName = string.Format("{0}: Name={1};", this.GetType().Name, this.Name);
            string teacherName = string.Format("Teacher={0};", this.Teacher.Name);
            result.Append(courseName);
            result.Append(teacherName);
            if (this.topics.Count > 0)
            {
                result.Append("Topics=[");
                result.Append(string.Join(", ", this.topics));
                result.Append("];");
            }

            if (this is LocalCourse)
            {
                result.Append(string.Format("Lab={0};", (this as LocalCourse).Lab));      
            }
            else if (this is OffsiteCourse)
            {
                result.Append(string.Format("Town={0};",(this as OffsiteCourse).Town));      
            }

            result.Length--;
            return result.ToString();
        }
    }
}