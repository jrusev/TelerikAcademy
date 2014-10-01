namespace Musicians.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Musicians.Models;

    public interface IMusiciansDBContext
    {
        IDbSet<Song> Songs { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

        void Dispose();
    }
}
