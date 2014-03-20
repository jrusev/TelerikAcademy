namespace School
{
    using System.Collections.Generic;

    public class Teacher : Person, ICommentable
    {
        public Teacher(string name)
            : base(name)
        {
        }

        // Each teacher teaches a set of disciplines.
        public List<Discipline> Disciplines { get; set; }

        // Teachers could have optional comments.
        public string Comment { get; set; }
    }  
}