namespace BugLogger.WebAPI.Models
{
    using System;
    using System.Linq.Expressions;
    using System.ComponentModel.DataAnnotations;

    using BugLogger.Models;

    public class BugModel
    {
        public BugModel(Bug bug)
        {
            this.Id = bug.Id;
            this.Text = bug.Text;
            this.Status = bug.Status.ToString();
            this.LogDate = bug.LogDate;
        }

        public static Expression<Func<Bug, BugModel>> FromBug
        {
            get { return bug => new BugModel(bug); }
        }

        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime LogDate { get; set; }
    }
}