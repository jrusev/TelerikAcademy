namespace Academy.Models
{
    using System;

    public class Homework
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Information { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
