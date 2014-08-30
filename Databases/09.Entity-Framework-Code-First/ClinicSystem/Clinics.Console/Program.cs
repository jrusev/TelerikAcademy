using System;
using Clinics.Models;
using Clinics.Data;
using System.Linq;

namespace Clinics.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Connecting to server...");

            using (var db = new ClinicsDB())
            {
                ClearDatabase(db);
                SeedDatabase(db);

                // Print all manipulations in the database
                Console.WriteLine(string.Join(Environment.NewLine, db.Manipulations.ToList()));
            }
        }

        private static void ClearDatabase(ClinicsDB db)
        {
            // In this order
            db.Manipulations.ToList().ForEach(x => db.Manipulations.Remove(x));
            db.Specialists.ToList().ForEach(x => db.Specialists.Remove(x));
            db.Specialties.ToList().ForEach(x => db.Specialties.Remove(x));
            db.Procedures.ToList().ForEach(x => db.Procedures.Remove(x));
            SaveChanges(db);
        }

        private static void SeedDatabase(ClinicsDB db)
        {
            var proc1 = new Procedure() { Name = "Blood test", Price = 50.00m };
            var proc2 = new Procedure() { Name = "MRI", Price = 1000.00m };

            var specialty = new Specialty() { Name = "Internist" };

            var specialist = new Specialist()
            {
                FirstName = "Gregory",
                LastName = "House",
                SpecialtyId = specialty.Id
            };

            var manip = new Manipulation()
            {
                Date = DateTime.Now,
                SpecialistId = specialist.Id
            };

            manip.Procedures.Add(proc1);
            manip.Procedures.Add(proc2);

            db.Procedures.Add(proc1);
            db.Procedures.Add(proc2);
            db.Specialties.Add(specialty);
            db.Specialists.Add(specialist);
            db.Manipulations.Add(manip);

            SaveChanges(db);
        }

        private static void SaveChanges(ClinicsDB db)
        {
            int rowsAffected = db.SaveChanges();
            Console.WriteLine("({0} row(s) affected)", rowsAffected);
        }
    }
}
