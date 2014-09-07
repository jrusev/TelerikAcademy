namespace Academy.ConsoleClient
{
    using System;
    using Academy.Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Connecting to server...");
            var db = new AcademyData();
            Console.WriteLine(string.Join(Environment.NewLine, db.Students.All()));
        }
    }
}
