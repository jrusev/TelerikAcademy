namespace School
{
    public class Student : Person, ICommentable
    {
        private string name;

        public Student(string name)
            : base(name)
        {
        }

        // Students have name and unique class number.
        public string ClassID { get; set; }

        // Students could have optional comments.
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