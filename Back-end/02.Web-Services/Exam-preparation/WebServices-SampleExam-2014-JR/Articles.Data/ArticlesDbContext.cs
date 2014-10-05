namespace Articles.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Articles.Models;
    using Articles.Data.Migrations;

    public class ArticlesDbContext : IdentityDbContext<User>
    {
        public ArticlesDbContext()
            : base("ArticlesDB", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticlesDbContext, Configuration>());
        }

        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Alert> Alerts { get; set; }

        public static ArticlesDbContext Create()
        {
            return new ArticlesDbContext();
        }
    }
}
