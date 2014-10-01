namespace ATM.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionLog
    {
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
