namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.Id = Guid.NewGuid();
            this.students = new HashSet<Student>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
