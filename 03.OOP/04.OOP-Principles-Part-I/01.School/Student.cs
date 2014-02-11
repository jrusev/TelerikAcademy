namespace School
{
    // We are given a school. In the school there are classes of students. Each class has a set of teachers.
    // Each teacher teaches a set of disciplines. Students have name and unique class number.
    // Classes have unique text identifier. Teachers have name.
    // Disciplines have name, number of lectures and number of exercises.
    // Both teachers and students are people.
    // Students, classes, teachers and disciplines could have optional comments (free text block).
    public class Student : Person, ICommentable
    {
        private string name;

        public Student(string name)
            : base(name)
        {
        }

        // Students have name and unique class number.
        public string ClassID { get; set; }

        public string Comment { get; set; }

        // Override the base class property 
        // to provide specialized accessor behavior. 
        public override string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    this.name = "Unknown";
                }
            }
        }
    }   
}