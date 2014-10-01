namespace BugLogger.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BugLogger.Models;

    public interface IBugLoggerDBContext
    {
        IDbSet<Bug> Bugs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

        void Dispose();
    }
}
