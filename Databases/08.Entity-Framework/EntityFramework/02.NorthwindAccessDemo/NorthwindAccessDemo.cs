using System;
using Northwind.Models;
using Northwind.DataAccess;

class NorthwindAccessDemo
{
    public static void Main()
    {
        Console.WriteLine("Connecting to database...");

        Console.WriteLine("Insert: ({0} affected row(s))", TestInsert());
        Console.WriteLine("Modify: ({0} affected row(s))", TestModify());
        Console.WriteLine("Delete: ({0} affected row(s))", TestDelete());
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
