namespace Articles.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
