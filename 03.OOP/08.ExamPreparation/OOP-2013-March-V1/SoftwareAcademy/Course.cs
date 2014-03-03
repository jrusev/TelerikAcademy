using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Course : ICourse
    {
        private string name;
        private IList<string> topics;

        public Course(string name, ITeacher teacher = null)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
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
                    throw new ArgumentNullException("Course name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        // Teacher can be null
        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException("Topic cannot be null or empty!");
            }

            this.topics.Add(topic);
        }

        // (course type): Name=(course name); Teacher=(teacher name);
        // Topics=[(course topics – comma separated)];
        // Lab=(lab name – when applicable); Town=(town name – when applicable);
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string courseName = string.Format("{0}: Name={1}; ", this.GetType().Name, this.Name);
            result.Append(courseName);

            if (this.Teacher != null)
            {
                string teacherName = string.Format("Teacher={0}; ", this.Teacher.Name);
                result.Append(teacherName);
            }

            if (this.topics.Count > 0)
            {
                result.Append("Topics=[");
                result.Append(string.Join(", ", this.topics));
                result.Append("]; ");
            }

            if (this is LocalCourse)
            {
                result.Append(string.Format("Lab={0};", (this as LocalCourse).Lab));
            }
            else if (this is OffsiteCourse)
            {
                result.Append(string.Format("Town={0};", (this as OffsiteCourse).Town));
            }

            result.Length--;
            return result.ToString();
        }
    }
}