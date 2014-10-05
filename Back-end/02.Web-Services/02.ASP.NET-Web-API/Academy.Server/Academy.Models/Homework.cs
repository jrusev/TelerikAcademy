namespace Academy.Models
{
    using System;

    public class Homework
    {
        public int Id { get; set; }

        public DateTime TimeSent { get; set; }

        public string Information { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
