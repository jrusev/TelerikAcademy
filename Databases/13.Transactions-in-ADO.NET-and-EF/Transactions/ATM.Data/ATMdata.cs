namespace ATM.Data
{
    using System.Data.Entity;
    using ATM.Models;
    using ATM.Data.Migrations;

    public class ATMdata : DbContext
    {
        public ATMdata()
            : base("ATMdata")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMdata, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }
        public IDbSet<TransactionLog> TransactionLogs { get; set; }
    }
}
