namespace DesignPatterns
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            var account = new Account("Jim Johnson");

            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
        }
    }

    // The 'Context' class
    internal class Account
    {
        public Account(string owner)
        {
            // New accounts are 'Silver' by default
            this.Owner = owner;
            this.State = new SilverState(0.0, this);
        }

        public double Balance
        {
            get { return this.State.Balance; }
        }

        public State State { get; set; }

        public string Owner { get; set; }

        public void Deposit(double amount)
        {
            this.State.Deposit(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status  = {0}", this.State.GetType().Name);
            Console.WriteLine();
        }

        public void Withdraw(double amount)
        {
            this.State.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status  = {0}\n", this.State.GetType().Name);
        }

        public void PayInterest()
        {
            this.State.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status  = {0}\n", this.State.GetType().Name);
        }
    }

    // The 'State' abstract class
    internal abstract class State
    {
        protected double interest;

        protected double lowerLimit;

        protected double upperLimit;

        public Account Account { get; set; }

        public double Balance { get; set; }

        public abstract void Deposit(double amount);

        public abstract void Withdraw(double amount);

        public abstract void PayInterest();
    }

    // A 'ConcreteState' class
    internal class SilverState : State
    {
        public SilverState(State state) :
            this(state.Balance, state.Account)
        {
        }

        public SilverState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;
            this.Initialize();
        }

        public override void Deposit(double amount)
        {
            this.Balance += amount;
            this.StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            this.Balance -= amount;
            this.StateChangeCheck();
        }

        public override void PayInterest()
        {
            this.Balance += this.interest * this.Balance;
            this.StateChangeCheck();
        }

        private void Initialize()
        {
            this.interest = 0.0;
            this.lowerLimit = 0.0;
            this.upperLimit = 1000.0;
        }

        private void StateChangeCheck()
        {
            if (this.Balance < this.lowerLimit)
            {
                this.Account.State = new RedState(this);
            }
            else if (this.Balance > this.upperLimit)
            {
                this.Account.State = new GoldState(this);
            }
        }
    }

    // A 'ConcreteState' class
    internal class RedState : State
    {
        public RedState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            this.Initialize();
        }

        public override void Deposit(double amount)
        {
            this.Balance += amount;
            this.StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest()
        {
            // No interest is paid
        }

        private void Initialize()
        {
            this.interest = 0.0;
            this.lowerLimit = -100.0;
            this.upperLimit = 0.0;
        }

        private void StateChangeCheck()
        {
            if (this.Balance > this.upperLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }

    // A 'ConcreteState' class
    internal class GoldState : State
    {
        public GoldState(State state)
            : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;
            this.Initialize();
        }

        public override void Deposit(double amount)
        {
            this.Balance += amount;
            this.StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            this.Balance -= amount;
            this.StateChangeCheck();
        }

        public override void PayInterest()
        {
            this.Balance += this.interest * this.Balance;
            this.StateChangeCheck();
        }

        private void Initialize()
        {
            this.interest = 0.05;
            this.lowerLimit = 1000.0;
            this.upperLimit = 10000000.0;
        }

        private void StateChangeCheck()
        {
            if (this.Balance < 0.0)
            {
                Account.State = new RedState(this);
            }
            else if (this.Balance < this.lowerLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }


}