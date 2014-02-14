namespace Bank.Common
{
    using System;

    public class DepositAccount : Account, IWithdrawable
    {
        public DepositAccount(Client client, decimal interstRateMonthly, string iban)
            : base(client, interstRateMonthly, iban)
        {
        }

        // Deposit accounts are allowed to withdraw money.
        public void WithdrawMoney(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ApplicationException("Withdraw amount larger than available balance!");
            }

            this.Balance -= amount;
        }

        public override decimal CalculateInterest(decimal months)
        {
            // Deposit accounts have no interest if their balance is positive and less than 1000.
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }

            return (this.InterstRateMonthlyPerc / 100) * this.Balance * months;
        }

        public override string ToString()
        {
            return base.ToString() + ", Type: Deposit";
        }
    }
}