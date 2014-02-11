namespace School
{
    using System.Collections.Generic;

    public class SchoolClass : ICommentable
    {
        // Classes have unique text identifier.
        public string ID { get; set; }

        // Each class has a set of teachers.
        public List<Teacher> Teachers { get; set; }

        // Classes could have optional comments.
        public string Comment { get; set; }
    }
}