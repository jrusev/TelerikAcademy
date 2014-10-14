namespace BullsCows.Data
{
    using BullsCows.Data.Repositories;
    using BullsCows.Models;

    public interface IBullsCowsData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Game> Games { get; }
        IRepository<Guess> Guesses { get; }
        IRepository<Notification> Notifications { get; }

        void SaveChanges();

        void Dispose();
    }
}
