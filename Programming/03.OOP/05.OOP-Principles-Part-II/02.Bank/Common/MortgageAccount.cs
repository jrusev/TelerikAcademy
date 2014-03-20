namespace Bank.Common
{
    using System;

    public class MortgageAccount : Account
    {
        public MortgageAccount(Client client, decimal interstRateMonthly, string iban)
            : base(client, interstRateMonthly, iban)
        {
        }

        // Mortgage accounts have ½ interest for the first 12 months for companies
        // and no interest for the first 6 months for individuals.
        public override decimal CalculateInterest(decimal months)
        {
            if (months < 0)
            {
                throw new ApplicationException("The number of months cannot be negative!");
            }

            if (months < 6 && this.Owner.IsIndividual)
            {
                return 0;
            }

            if (months < 12 && !this.Owner.IsIndividual)
            {
                return (this.InterstRateMonthlyPerc * 0.5m / 100) * this.Balance * months;
            }

            return (this.InterstRateMonthlyPerc / 100) * this.Balance * months;
        }

        public override string ToString()
        {
            return base.ToString() + ", Type: Mortgage";
        }
    }
}
