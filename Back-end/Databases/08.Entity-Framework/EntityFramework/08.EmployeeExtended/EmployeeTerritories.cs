using System;
using Northwind.Models;
using System.Data.Linq;

// By inheriting the Employee entity class create a class which
// allows employees to access their corresponding territories as property of type EntitySet<T>.
class EmployeeTerritories
{
    static void Main()
    {
        Console.WriteLine("Connecting to server...");

        var db = new NorthwindEntities();
        int employeeID = 1;
        Employee employee = db.Employees.Find(employeeID);

        // Property added at Northwind.Models EmployeeExtended file
        EntitySet<Territory> territories = employee.TerritoriesSet;
        Console.WriteLine("All territories for employee with ID {0} are:", employeeID);

        foreach (var territory in territories)
        {
            Console.WriteLine(territory.TerritoryDescription);
        }
    }
}

