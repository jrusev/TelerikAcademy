using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinics.Models
{
    public class Specialist
    {
        public Specialist()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public Guid SpecialtyId { get; set; }

        [ForeignKey("SpecialtyId")]
        public virtual Specialty Specialty { get; set; }

        public override string ToString()
        {
            var result = string.Format(
                "{0} {1} ({2})",
                this.FirstName,
                this.LastName,
                this.Specialty.Name);

            return result;
        }
    }
}
