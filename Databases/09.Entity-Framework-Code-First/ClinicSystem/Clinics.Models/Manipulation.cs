using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinics.Models
{
    public class Manipulation
    {
        private ICollection<Procedure> procedures;

        public Manipulation()
        {
            this.Id = Guid.NewGuid();
            this.procedures = new HashSet<Procedure>();
        }

        public Guid Id { get; set; }

        public Guid SpecialistId { get; set; }

        [ForeignKey("SpecialistId")]
        public virtual Specialist Specialist { get; set; }

        public virtual ICollection<Procedure> Procedures
        {
            get { return this.procedures; }
            set { this.procedures = value; }
        }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            var result = string.Format(
                "{0} : {1} | {2}",
                this.Date.ToShortDateString(),
                string.Join(", ", this.Procedures),
                this.Specialist);

            return result;
        }
    }
}
