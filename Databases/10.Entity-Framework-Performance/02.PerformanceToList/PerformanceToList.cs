using System;
using System.Linq;
using TelerikAcademy.Model;
using System.Diagnostics;

// Using Entity Framework write a query that selects all employees from the Telerik Academy database,
// then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns,
// then invokes ToList() and finally checks whether the town is "Sofia".
// Rewrite the same in more optimized way and compare the performance.
public class PerformanceToList
{
    public static void Main()
    {
        SlowToListOperation();
        FastToListOperation();

        Console.WriteLine();

        SlowToListOperation();
        FastToListOperation();

        Console.WriteLine();

        SlowToListOperation();
        FastToListOperation();
    }

    public static void SlowToListOperation()
    {
        using (var context = new TelerikAcademyEntities())
        {
            var sw = Stopwatch.StartNew();

            var sofiaEmployees = context.Employees.Select(e => e).ToList().Select(e => e.Address).ToList().Select(a => a.Town).
                ToList().Where(t => t.Name.ToLower() == "sofia");

            var count = sofiaEmployees.Count();
            sw.Stop();
            Console.WriteLine("Slow: {0} milliseconds.", sw.Elapsed.TotalMilliseconds);
        }
    }

    public static void FastToListOperation()
    {
        using (var context = new TelerikAcademyEntities())
        {
            var sw = Stopwatch.StartNew();

            var sofiaEmployees = context.Employees.Select(e => e).Select(e => e.Address).Select(a => a.Town)
                .Where(t => t.Name.ToLower() == "sofia");

            var count = sofiaEmployees.Count();
            sw.Stop();
            Console.WriteLine("Slow: {0} milliseconds.", sw.Elapsed.TotalMilliseconds);
        }
    }
}
