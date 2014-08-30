using System;
using System.ComponentModel.DataAnnotations;


namespace Clinics.Models
{
    public class Procedure
    {
        public Procedure()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1:C})", this.Name, this.Price);
        }
    }
}
