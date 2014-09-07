using System;
using Academy.Data;

namespace Academy.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Connecting to server...");
            var db = new ClinicsData();
            Console.WriteLine(string.Join(Environment.NewLine, db.Students.All()));
        }
    }
}
