using System;
using System.ComponentModel.DataAnnotations;

namespace Clinics.Models
{
    public class Specialty
    {
        public Specialty()
        {
            this.Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
