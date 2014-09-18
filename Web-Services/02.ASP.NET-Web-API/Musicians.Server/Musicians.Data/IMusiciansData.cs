namespace Musicians.Data
{
    using Musicians.Data.Repositories;
    using Musicians.Models;

    public interface IMusiciansData
    {
        IGenericRepository<Song> Songs { get; }

        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Album> Albums { get; }

        void SaveChanges();

        void Dispose();
    }
}
