namespace Academy.Data
{
    using Academy.Data.Repositories;
    using Academy.Models;

    public interface IClinicsData
    {
        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Homework> Homeworks { get; }

        IGenericRepository<Student> Students { get; }

        void SaveChanges();

        void Dispose();
    }
}
