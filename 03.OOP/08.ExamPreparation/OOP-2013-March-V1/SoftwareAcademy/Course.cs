using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string name;
        private IList<string> topics;

        protected Course(string name, ITeacher teacher = null)
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

        // (course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string courseName = string.Format("{0}: Name={1}", this.GetType().Name, this.Name);
            result.Append(courseName);

            if (this.Teacher != null)
            {
                string teacherName = string.Format("; Teacher={0}", this.Teacher.Name);
                result.Append(teacherName);
            }

            if (this.topics.Count > 0)
            {
                result.Append("; Topics=[");
                result.Append(string.Join(", ", this.topics));
                result.Append("]");
            }

            return result.ToString();
        }
    }
}