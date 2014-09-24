namespace BugLogger.Data
{
    using BugLogger.Data.Repositories;
    using BugLogger.Models;

    public interface IBugLoggerData
    {
        IGenericRepository<Bug> Bugs { get; }

        void SaveChanges();

        void Dispose();
    }
}
