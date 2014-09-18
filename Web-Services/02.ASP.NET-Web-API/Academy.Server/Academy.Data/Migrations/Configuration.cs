namespace Academy.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AcademyDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Academy.Data.AcademyDBContext";
        }

        protected override void Seed(AcademyDBContext context)
        {
        }
    }
}