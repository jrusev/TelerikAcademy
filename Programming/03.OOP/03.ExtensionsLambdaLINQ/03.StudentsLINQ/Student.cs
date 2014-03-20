namespace Students
{
    public class Student
    {
        public Student(string fristName, string lastName, byte age = 0)
        {
            this.FristName = fristName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public byte Age { get; set; }

        public override string ToString()
        {
            string studentStr = string.Format("{0} {1}", this.FristName, this.LastName);
            if (this.Age > 0)
            {
                studentStr += string.Format(" (age: {0})", this.Age);
            }

            return studentStr;
        }
    }
}