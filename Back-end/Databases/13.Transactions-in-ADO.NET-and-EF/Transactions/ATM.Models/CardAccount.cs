namespace ATM.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CardAccount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string CardPIN { get; set; }

        public decimal CardCash { get; set; }

        public override string ToString()
        {
            return string.Format("Acc#{0} : {1:C}", this.Id, this.CardCash);
        }
    }
}
