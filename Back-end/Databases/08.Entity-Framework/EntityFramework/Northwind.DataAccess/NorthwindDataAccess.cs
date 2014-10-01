namespace Northwind.DataAccess
{
    using System.Collections.Generic;
    using System.Linq;
    using Northwind.Models;

    // Create a DAO class with static methods which provide functionality for
    // inserting, modifying and deleting customers. Write a testing class.
    public static class NorthwindDataAccess
    {
        public static int InsertCustomer(Customer customer)
        {
            var affectedRows = 0;
            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(customer);
                affectedRows = db.SaveChanges();
            }

            return affectedRows;
        }

        public static int ModifyCustomerAddress(string customerID, string newAddress)
        {
            var affectedRows = 0;
            using (var db = new NorthwindEntities())
            {
                var targetCustomer = db.Customers.Find(customerID);
                targetCustomer.Address = newAddress;
                affectedRows = db.SaveChanges();
            }

            return affectedRows;
        }

        public static int DeleteCustomerById(string customerID)
        {
            var affectedRows = 0;
            using (var db = new NorthwindEntities())
            {
                Customer customerToDelete = db.Customers.Find(customerID);
                if (customerToDelete != null)
                {
                    db.Customers.Remove(customerToDelete);
                    affectedRows = db.SaveChanges();
                }
            }

            return affectedRows;
        }

        public static Customer GetCustomerByID(string customerID)
        {
            using (var db = new NorthwindEntities())
            {
                return db.Customers.FirstOrDefault(c => c.CustomerID == customerID);
            }
        }

        public static IEnumerable<string> GetCustomersByOrderSQL(int year, string shipCountry)
        {
            var northwind = new NorthwindEntities();
            string query =
                @"SELECT DISTINCT c.ContactName
                FROM Orders o
                JOIN Customers c ON o.CustomerID = c.CustomerID
                WHERE YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1}
                ORDER BY c.ContactName";

            object[] parameters = { year, shipCountry };
            var customers = northwind.Database.SqlQuery<string>(query, parameters);

            return customers;
        }
    }
}
