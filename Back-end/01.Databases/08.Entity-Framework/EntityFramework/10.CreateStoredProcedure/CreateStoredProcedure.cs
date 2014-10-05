using System;
using System.Linq;
using Northwind.Models;

// Create a stored procedures in the Northwind database
// for finding the total incomes for given supplier name and period (start date, end date).
// Implement a C# method that calls the stored procedure and returns the retuned record set.
public class CreateStoredProcedure
{
    public static void Main()
    {
        // You must first execute the script for generating the stored procedure (inluded as "StoredProcedureQuery.sql")
        // Then map the procedure to the name GetSupplierIncome via the database model:
        // right-click on the model - update, right-click again - add new - function import.
        Console.WriteLine("Connecting to server...");

        using (NorthwindEntities northwindEntites = new NorthwindEntities())
        {
            var result = (double)northwindEntites
                .GetSupplierIncome(1, new DateTime(1996, 7, 15), new DateTime(1996, 8, 24))
                .FirstOrDefault();

            Console.WriteLine("{0:#.00}", result);
        }
    }
}
