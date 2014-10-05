using System;
using TelerikAcademy.Model;
using System.Diagnostics;

// Using Entity Framework write a SQL query to select all employees from the Telerik Academy database
// and later print their name, department and town. Try the both variants: with and without .Include().
// Compare the number of executed SQL statements and the performance.
public class PerformanceSelectQueries
{
    public static void Main()
    {
        SlowEmployeeQuery();
        FastEmployeeQuery();

        Console.WriteLine();

        SlowEmployeeQuery();
        FastEmployeeQuery();

        Console.WriteLine();

        SlowEmployeeQuery();
        FastEmployeeQuery();
    }

    public static void SlowEmployeeQuery()
    {
        using (var context = new TelerikAcademyEntities())
        {
            var sw = Stopwatch.StartNew();
            foreach (var employee in context.Employees)
            {
                var Name = employee.LastName;
                var Department = employee.Department.Name;
                var Town = employee.Address.Town.Name;
            }

            sw.Stop();
            Console.WriteLine("Slow: {0} milliseconds.", sw.Elapsed.TotalMilliseconds);
        }
    }

    public static void FastEmployeeQuery()
    {
        using (var context = new TelerikAcademyEntities())
        {
            var sw = Stopwatch.StartNew();
            foreach (var employee in context.Employees.Include("Department").Include("Address.Town"))
            {
                var Name = employee.LastName;
                var Department = employee.Department.Name;
                var Town = employee.Address.Town.Name;
            }

            sw.Stop();
            Console.WriteLine("Fast: {0} milliseconds.", sw.Elapsed.TotalMilliseconds);
        }
    }
}
