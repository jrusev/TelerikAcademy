namespace School
{
    // Students, classes, teachers and disciplines could have optional comments (free text block).
    public interface ICommentable
    {
        string Comment { get; set; }
    } 
}