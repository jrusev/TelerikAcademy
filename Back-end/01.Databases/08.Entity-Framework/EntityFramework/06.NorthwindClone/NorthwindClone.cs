using Northwind.Models;
using System;
using System.Linq;

// Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.
class NorthwindClone
{
    public static void Main()
    {
        Console.WriteLine("Connecting to server...");

        using (var northwindEntities = new NorthwindEntities())
        {
            var created = northwindEntities.Database.CreateIfNotExists();
            if (created)
            {
                Console.WriteLine("NorthwindTwin database created!");
            }            
        }
    }
}
