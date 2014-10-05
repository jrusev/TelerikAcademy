namespace Musicians.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Musicians.Data.Migrations;
    using Musicians.Models;

    public class MusiciansDBContext : DbContext, IMusiciansDBContext
    {
        public MusiciansDBContext()
            : base("MusiciansConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusiciansDBContext, Configuration>());
        }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Album> Albums { get; set; }

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
