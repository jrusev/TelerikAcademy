namespace School
{
    using System.Collections.Generic;

    // We are given a school. In the school there are classes of students. Each class has a set of teachers.
    // Each teacher teaches a set of disciplines. Students have name and unique class number.
    // Classes have unique text identifier. Teachers have name.
    // Disciplines have name, number of lectures and number of exercises.
    // Both teachers and students are people.
    // Students, classes, teachers and disciplines could have optional comments (free text block).
    public class School
    {
        // In the school there are classes of students.
        public List<SchoolClass> Classes { get; set; }
    }
}