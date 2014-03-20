namespace Bank.Common
{
    using System;

    // All accounts have customer, balance and interest rate (monthly based).
    public abstract class Account
    {
        private decimal interstRateMonthlyPerc;
        private string iban;

        protected Account(Client client, decimal interstRateMonthly, string iban)
        {
            this.Owner = client;
            this.InterstRateMonthlyPerc = interstRateMonthly;
            this.IBAN = iban;
        }

        public string IBAN
        {
            get
            {
                return this.iban;
            }

            private set
            {
                if (!this.IsIBANvalid(value))
                {
                    throw new ApplicationException("IBAN is not valid!");
                }

                this.iban = value;
            }
        }

        /// <summary>
        /// Monthly interest rate in percent.
        /// </summary>
        public decimal InterstRateMonthlyPerc 
        {
            get
            {
                return this.interstRateMonthlyPerc;
            }

            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Interest rate cannot be negative!");   
                }

                this.interstRateMonthlyPerc = value;
            }
        }

        public decimal Balance { get; protected set; }

        public Client Owner { get; private set; }

        // Deposit, loan and mortgage accounts can deposit money.
        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ApplicationException("Deposited amount cannot be negative or zero!");
            }

            this.Balance += amount;
        }

        // All accounts can calculate their interest amount for a given period (in months).
        public abstract decimal CalculateInterest(decimal months);

        public override string ToString()
        {
            return string.Format("IBAN: {0}, Owner: {1,-10}, Balance: {2,5}", this.IBAN, this.Owner.Name, this.Balance);
        }

        private bool IsIBANvalid(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban))
            {
                return false;
            }

            // TODO: Check for IBAN validty
            return true;
        }
    }
}