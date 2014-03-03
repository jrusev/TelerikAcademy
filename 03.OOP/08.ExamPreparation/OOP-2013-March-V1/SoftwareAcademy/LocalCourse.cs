using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string laboratory)
            : base(name, teacher)
        {
            this.Lab = laboratory;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Lab name cannot be null or empty!");
                }

                this.lab = value;
            }
        }

        // Lab=(lab name)
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Append(string.Format("; Lab={0}", this.Lab));

            return result.ToString();
        }
    }
}