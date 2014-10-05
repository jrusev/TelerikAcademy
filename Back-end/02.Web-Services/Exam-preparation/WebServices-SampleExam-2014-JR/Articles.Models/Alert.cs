namespace Articles.Models
{
    using System;

    public class Alert
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
