namespace Academy.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using Academy.Models;

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return course => new CourseModel
                {
                    Id = course.Id,
                    CourseName = course.Name,
                    Students = course.Students.Select(s => s.FirstName + " " + s.LastName)
                };
            }
        }

        public Guid Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        public IEnumerable<string> Students { get; set; }
    }
}