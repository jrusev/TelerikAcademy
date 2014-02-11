namespace School
{
    using System;

    // We are given a school. In the school there are classes of students. Each class has a set of teachers.
    // Each teacher teaches a set of disciplines. Students have name and unique class number.
    // Classes have unique text identifier. Teachers have name.
    // Disciplines have name, number of lectures and number of exercises.
    // Both teachers and students are people.
    // Students, classes, teachers and disciplines could have optional comments (free text block).
    public abstract class Person
    {
        private string name;

        protected Person(string name)
        {
            this.Name = name;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null or empty!");
                }

                this.name = value;
            }
        }
    } 
}