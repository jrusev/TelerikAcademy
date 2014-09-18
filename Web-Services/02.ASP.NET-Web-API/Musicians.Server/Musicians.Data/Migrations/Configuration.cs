namespace Musicians.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<MusiciansDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Musicians.Data.MusiciansDBContext";
        }

        protected override void Seed(MusiciansDBContext context)
        {
        }
    }
}