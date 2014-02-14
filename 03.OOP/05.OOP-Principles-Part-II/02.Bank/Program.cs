namespace Bank.Test
{
    using System;
    using Common;

    internal class Program
    {
        // Write a program to model the bank system by classes and interfaces.
        // Identify the classes, interfaces, base classes and abstract actions
        // and implement the calculation of the interest functionality through overridden methods.
        private static void Main()
        {
            Client client1 = new ClientIndividual("Neo");
            Client client2 = new ClientCompany("Office 1");
            Client client3 = new ClientIndividual("Nakov");

            Account acc1 = new DepositAccount(client1, 5, "BG13TLRK01");
            Account acc2 = new LoanAccount(client2, 4.5m, "BG13TLRK02");
            Account acc3 = new MortgageAccount(client3, 8.8m, "BG13TLRK03");

            acc1.DepositMoney(1000);
            ((DepositAccount)acc1).WithdrawMoney(500);
            acc2.DepositMoney(10000);

            Bank bank = new Bank("New Bank");

            bank.AddAccount(acc1);
            bank.AddAccount(acc2);
            bank.AddAccount(acc3);

            Console.WriteLine(bank.Accounts);

            Console.WriteLine();
            Console.WriteLine("IBAN: {0} ({1}), Interest: {2:F2}", acc1.IBAN, acc1.Owner.Name, acc1.CalculateInterest(5));
            Console.WriteLine("IBAN: {0} ({1}), Interest: {2:F2}", acc2.IBAN, acc2.Owner.Name, acc2.CalculateInterest(6));
            Console.WriteLine("IBAN: {0} ({1}), Interest: {2:F2}", acc3.IBAN, acc3.Owner.Name, acc3.CalculateInterest(18));

            Console.WriteLine("\nRemoving account 1");
            bank.RemoveAccount(acc1);
            Console.WriteLine(bank.Accounts);
        }
    }
}