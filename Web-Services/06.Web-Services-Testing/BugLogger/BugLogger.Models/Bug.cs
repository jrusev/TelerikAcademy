namespace BugLogger.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        public int Id { get; set; }

        [Required]
        public BugStatus Status { get; set;  }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime LogDate { get; set; }
    }
}
