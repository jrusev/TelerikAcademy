using System;

class BankAccount
{
    static void Main()
    {
        // A bank account has a holder name (first name, middle name and last name),
        // available amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers associated with the account.
        // Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

        string firstName;
        string middleName;
        string lastName;
        decimal balance;
        string bankName;
        string IBAN;
        string BIC;
        // some card numbers have up to 19 digitis, which only a var of type 'long' can contain; to be safe we use 'string'
        string creditCardNum1; 
        string creditCardNum2;
        string creditCardNum3;

        firstName = "Michael";
        middleName = "Air";
        lastName = "Jordan";
        balance = 10000000.23m;
        bankName = "ABN AMRO BANK (SWITZERLAND) A.G.";
        IBAN = "CH9300762011623852957";
        BIC = "ABNACHZZXXX";
        creditCardNum1 = "4532385721075269";
        creditCardNum2 = "4916463574482514";
        creditCardNum3 = "4716166878783261";

        Console.WriteLine("First Name:\t{0}",firstName);
        Console.WriteLine("Middle Name:\t{0}", middleName);
        Console.WriteLine("Last Name:\t{0}", lastName);
        Console.WriteLine("Balance:\t{0}", balance);
        Console.WriteLine("Bank:\t{0}", bankName);
        Console.WriteLine("IBAN:\t{0}", IBAN);
        Console.WriteLine("BIC:\t{0}", BIC);
        Console.WriteLine("Credit card 1:\t{0}", creditCardNum1);
        Console.WriteLine("Credit card 2:\t{0}", creditCardNum2);
        Console.WriteLine("Credit card 3:\t{0}", creditCardNum3);
    }
}