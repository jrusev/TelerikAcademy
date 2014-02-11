namespace School
{
    using System.Collections.Generic;

    // We are given a school. In the school there are classes of students. Each class has a set of teachers.
    // Each teacher teaches a set of disciplines. Students have name and unique class number.
    // Classes have unique text identifier. Teachers have name.
    // Disciplines have name, number of lectures and number of exercises.
    // Both teachers and students are people.
    // Students, classes, teachers and disciplines could have optional comments (free text block).
    public class Teacher : Person, ICommentable
    {
        public Teacher(string name)
            : base(name)
        {
        }

        // Each teacher teaches a set of disciplines.
        public List<Discipline> Disciplines { get; set; }

        public string Comment { get; set; }
    }  
}