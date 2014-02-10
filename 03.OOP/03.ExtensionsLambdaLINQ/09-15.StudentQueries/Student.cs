namespace StudentQueries
{
    using System.Collections.Generic;

    // Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber.
    public class Student
    {
        private List<decimal> marks;

        public Student(string firstName, string lastName, string email, string phone, int facultyNum, int groupNumber, List<decimal> marks = null)
        {
            this.FristName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.FacultyNum = facultyNum;
            this.GroupNumber = groupNumber;
            this.Marks = marks;
            this.Phone = phone;
        }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int FacultyNum { get; set; }

        public int GroupNumber { get; set; }

        public List<decimal> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FristName, this.LastName);
        }
    }
}