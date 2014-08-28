using System;
using Northwind.DataAccess;

class CustomersByOrderSQL
{
    // Implement previous by using native SQL query and executing it through the DbContext.
    static void Main()
    {
        Console.WriteLine("Customers who have orders made in 1997 and shipped to Canada:");

        Console.WriteLine("Connecting to database...");
        foreach (var customer in NorthwindDataAccess.GetCustomersByOrderSQL(1997, "Canada"))
        {
            Console.WriteLine(customer);
        }
    }
}
