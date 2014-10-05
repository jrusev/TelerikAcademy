namespace Articles.Data
{
    using Articles.Data.Repositories;
    using Articles.Models;

    public interface IArticlesData
    {
        IRepository<Article> Articles { get; }
        IRepository<Category> Categories { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Like> Likes { get; }

        void SaveChanges();

        void Dispose();
    }
}
