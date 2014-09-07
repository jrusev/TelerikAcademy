namespace Academy.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Academy.Models;

    public interface IClinicsDBContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<Student> Students { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

        void Dispose();
    }
}
