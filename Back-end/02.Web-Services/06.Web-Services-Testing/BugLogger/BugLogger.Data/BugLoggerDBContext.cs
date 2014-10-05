namespace BugLogger.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BugLogger.Data.Migrations;
    using BugLogger.Models;

    public class BugLoggerDBContext : DbContext, IBugLoggerDBContext
    {
        public BugLoggerDBContext()
            : base("BugLogger")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDBContext, Configuration>());
        }

        public IDbSet<Bug> Bugs { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}
