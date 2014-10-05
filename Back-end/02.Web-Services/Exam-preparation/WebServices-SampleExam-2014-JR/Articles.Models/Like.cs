namespace Articles.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
