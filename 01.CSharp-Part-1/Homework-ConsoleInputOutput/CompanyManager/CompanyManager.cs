using System;

class CompanyManager
{
    static void Main()
    {
        // A company has name, address, phone number, fax number, web site and manager.
        // The manager has first name, last name, age and a phone number.
        // Write a program that reads the information about a company and its manager and prints them on the console.

        // Company
        Console.WriteLine("Please enter...");
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Company phone number: ");
        string companyPhone = Console.ReadLine();
        Console.Write("Company fax number: ");
        string companyFax = Console.ReadLine();
        Console.Write("Company web site: ");
        string companyWebsite = Console.ReadLine();

        // Manager
        Console.WriteLine();
        Console.WriteLine("Manager:");
        Console.Write("First name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Age: ");
        string managerAge = Console.ReadLine();
        Console.Write("Phone: ");
        string managerPhone = Console.ReadLine();

        // Print information
        Console.WriteLine();
        Console.WriteLine("Company name: {0}", companyName);
        Console.WriteLine("Company address: {0}", companyAddress);
        Console.WriteLine("Company phone number: {0}", companyPhone);
        Console.WriteLine("Company fax number: {0}", companyFax);
        Console.WriteLine("Company web site: {0}", companyWebsite);

        Console.WriteLine();
        Console.WriteLine("Manager:");
        Console.WriteLine("First name: {0}", managerFirstName);
        Console.WriteLine("Last name: {0}", managerLastName);
        Console.WriteLine("Age: {0}", managerAge);
        Console.WriteLine("Phone: {0}", managerPhone);
    }
}