namespace Human
{
    using System.Collections;
    using System.Collections.Generic;

    // Define new class Student which is derived from Human and has new field – grade.
    public class Student : Human
    {
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-20} Grade: {1}", base.ToString(), this.Grade);
        }
    }
}
