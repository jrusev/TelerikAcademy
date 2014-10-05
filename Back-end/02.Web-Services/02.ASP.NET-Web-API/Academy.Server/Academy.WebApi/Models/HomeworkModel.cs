namespace Academy.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    using Academy.Models;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return hw => new HomeworkModel
                {
                    Id = hw.Id,
                    TimeSent = hw.TimeSent,
                    Course = hw.Course.Name,
                    Student = hw.Student.FirstName + " " +  hw.Student.LastName
                };
            }
        }

        public int Id { get; set; }

        public DateTime TimeSent { get; set; }

        public string Course { get; set; }

        public string Student { get; set; }
    }
}