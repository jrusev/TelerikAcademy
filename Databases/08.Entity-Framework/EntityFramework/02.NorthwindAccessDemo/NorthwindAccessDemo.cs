using System;
using Northwind.Models;
using Northwind.DataAccess;

// Create a DAO class with static methods which provide functionality for
// inserting, modifying and deleting customers. Write a testing class.
class NorthwindAccessDemo
{
    public static void Main()
    {
        Console.WriteLine("Connecting to server...");

        Console.WriteLine("Insert: ({0} row(s) affected)", TestInsert());
        Console.WriteLine("Modify: ({0} row(s) affected)", TestModify());
        Console.WriteLine("Delete: ({0} row(s) affected)", TestDelete());
    }

    private static int TestInsert()
    {
        var customer = new Customer() { CustomerID = "TEST", CompanyName = "Test Company" };
        return NorthwindDataAccess.InsertCustomer(customer);
    }

    private static int TestModify()
    {
        return NorthwindDataAccess.ModifyCustomerAddress("TEST", "New address");
    }

    private static int TestDelete()
    {
        return NorthwindDataAccess.DeleteCustomerById("TEST");
    }
}
