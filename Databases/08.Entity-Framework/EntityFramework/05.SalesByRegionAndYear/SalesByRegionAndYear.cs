using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Models;

class SalesByRegionAndYear
{
    // Write a method that finds all the sales by specified region and period (start / end dates).
    static void Main()
    {
        Console.WriteLine("Find all sales by specified region and period (start / end dates):");

        Console.WriteLine("Connecting to database...");
        foreach (var order in GetOrdersByRegionAndYear("RJ", new DateTime(1998, 4, 30), DateTime.Now))
        {
            Console.WriteLine("{0,-12:dd.MM.yyyy}{1,-8}", order.OrderDate, order.OrderID);
        }
    }

    public static IEnumerable<Order> GetOrdersByRegionAndYear(string region, DateTime start, DateTime end)
    {
        using (var db = new NorthwindEntities())
        {
            var orders = db.Orders
                .Where(o => o.OrderDate != null && o.OrderDate.Value > start && o.OrderDate.Value < end)
                .ToList();

            return orders;
        }
    }
}
