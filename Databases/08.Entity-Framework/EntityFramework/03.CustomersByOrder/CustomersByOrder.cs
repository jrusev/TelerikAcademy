using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Models;

class CustomersByOrder
{
    // Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
    static void Main()
    {
        Console.WriteLine("Customers who have orders made in 1997 and shipped to Canada:");

        Console.WriteLine("Connecting to database...");
        foreach (var customer in GetCustomersByOrderLinq(1997, "Canada"))
        {
            Console.WriteLine(customer);
        }
    }

    public static IEnumerable<string> GetCustomersByOrderLinq(int year, string shipCountry)
    {
        using (var db = new NorthwindEntities())
        {
            var customers = db.Orders
                .Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == shipCountry)
                .Select(c => c.Customer.ContactName).Distinct().ToList();

            return customers;
        }
    }
}