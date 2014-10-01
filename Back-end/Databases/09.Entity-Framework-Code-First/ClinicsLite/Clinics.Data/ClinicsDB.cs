namespace Clinics.Data
{
    using System.Data.Entity;
    using Clinics.Models;
    using Clinics.Data.Migrations;

    public class ClinicsDB : DbContext
    {
        public ClinicsDB()
            : base("ClinicsLite")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClinicsDB, Configuration>());
        }

        public IDbSet<Specialist> Specialists { get; set; }

        public IDbSet<Specialty> Specialties { get; set; }

        public IDbSet<Manipulation> Manipulations { get; set; }

        public IDbSet<Procedure> Procedures { get; set; }
    }
}
