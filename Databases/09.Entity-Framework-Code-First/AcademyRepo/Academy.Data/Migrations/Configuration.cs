namespace Academy.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AcademyDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Clinics.Data.ClinicsDBContex";
        }

        protected override void Seed(AcademyDBContext context)
        {
        }
    }
}