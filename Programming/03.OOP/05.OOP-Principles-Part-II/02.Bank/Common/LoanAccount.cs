namespace Bank.Common
{
    using System;

    public class LoanAccount : Account
    {
        public LoanAccount(Client client, decimal interstRateMonthly, string iban)
            : base(client, interstRateMonthly, iban)
        {
        }

        // Loan accounts have no interest for the first 3 months if are held by individuals
        // and for the first 2 months if are held by a company.
        public override decimal CalculateInterest(decimal months)
        {
            if (months < 0)
            {
                throw new ApplicationException("The number of months cannot be negative!"); 
            }

            if (months < 3 && this.Owner.IsIndividual)
            {
                return 0;
            }

            if (months < 2 && !this.Owner.IsIndividual)
            {
                return 0;
            }

            return (this.InterstRateMonthlyPerc / 100) * this.Balance * months;
        }

        public override string ToString()
        {
            return base.ToString() + ", Type: Loan";
        }
    }
}
