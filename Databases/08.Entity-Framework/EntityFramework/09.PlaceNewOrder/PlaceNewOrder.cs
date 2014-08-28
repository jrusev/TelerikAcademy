using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Northwind.Models;

// Create a method that places a new order in the Northwind database.
// The order should contain several order items.
// Use transaction to ensure the data consistency.
public class Program
{
    public static void Main()
    {
        int shipperId = 2;
        string customerId = "BLONP";
        int employeeId = 8;
        string destination = "Quatar";

        Console.WriteLine("Connecting to server...");
        InsertOrder(shipperId, customerId, employeeId, destination);
    }

    public static void InsertOrder(int shipperId, string customerId, int employeeId, string destination)
    {
        using (var db = new NorthwindEntities())
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    Order orderToInsert = new Order
                    {
                        CustomerID = customerId,
                        EmployeeID = employeeId,
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)),
                        ShipVia = shipperId,
                        Freight = 3000000,
                        ShipCountry = destination,
                        Customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId),
                        Employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeId),
                        Shipper = db.Shippers.FirstOrDefault(s => s.ShipperID == shipperId),
                        Order_Details = new HashSet<Order_Detail>()
                    };

                    orderToInsert.Order_Details.Add(new Order_Detail
                    {
                        ProductID = 2,
                        Quantity = 34,
                        Discount = 1,
                        Order = orderToInsert
                    });

                    orderToInsert.Order_Details.Add(new Order_Detail
                    {
                        ProductID = 3,
                        Quantity = 70,
                        Discount = 1,
                        Order = orderToInsert
                    });

                    orderToInsert.Order_Details.Add(new Order_Detail
                    {
                        ProductID = 4,
                        Quantity = 110,
                        Discount = 1,
                        Order = orderToInsert
                    });

                    db.Orders.Add(orderToInsert);

                    int rowsAffected = db.SaveChanges();
                    scope.Complete();

                    Console.WriteLine("({0} row(s) affected)", rowsAffected);

                    int orderId = orderToInsert.OrderID;
                    Console.WriteLine("OrderId = {0}", orderId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
