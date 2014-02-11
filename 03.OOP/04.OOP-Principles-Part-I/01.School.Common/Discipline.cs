namespace School
{
    public class Discipline : ICommentable
    {
        // Disciplines have name, number of lectures and number of exercises.
        public string Name { get; set; }

        public int Lectures { get; set; }

        public int Exercises { get; set; }

        // Disciplines could have optional comments.
        public string Comment { get; set; }
    } 
}