namespace Bank.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bank
    {
        private Dictionary<string, Account> accountRegistry;

        public Bank(string name)
        {
            this.accountRegistry = new Dictionary<string, Account>();
            this.Name = name;
        }

        public string Name { get; private set; }

        /// <summary>
        /// Returns a list of accounts as strings.
        /// </summary>
        public string Accounts
        {
            get { return string.Join(Environment.NewLine, new List<Account>(this.accountRegistry.Values)); }
        }

        public void AddAccount(Account account)
        {
            if (this.accountRegistry.ContainsKey(account.IBAN))
            {
                throw new ApplicationException("Trying to add an account that already extists!");
            }

            this.accountRegistry[account.IBAN] = account;
        }

        public void RemoveAccount(Account account)
        {
            if (!this.accountRegistry.ContainsKey(account.IBAN))
            {
                throw new ApplicationException("Account does not exist!");
            }

            this.accountRegistry.Remove(account.IBAN);
        }
    }
}