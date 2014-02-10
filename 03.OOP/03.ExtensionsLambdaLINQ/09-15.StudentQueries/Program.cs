namespace StudentQueries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        // Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber.
        // Create a List<Student> with sample students.
        // Exercises:
        // 09. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
        // 10. Implement the previous using the same query expressed with extension methods.
        // 11. Extract all students that have email in abv.bg. Use string methods and LINQ.
        // 12. Extract all students with phones in Sofia. Use LINQ.
        // 13. Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
        // 14. Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
        // 15. Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        private static List<Student> students;

        private static void Main()
        {
            // Create a list of students
            FillFaculty();

            // Print all students
            Console.WriteLine("All students:");
            PrintStudents(students);

            // 09.Select the students that are from group number 2, ordered by FirstName. Use LINQ query.
            PrintGroupLinq(2);

            // 10.Select the students that are from group number 2, ordered by FirstName. Use extension methods.
            PrintGroupLambda(2);

            // 11.Extract all students that have email in abv.bg. Use string methods and LINQ.
            PrintGroupEmail("abv.bg");

            // 12.Extract all students with phones in Sofia. Use LINQ.
            PrintGroupPhones("359 2");

            // 13.Select all students that have at least one mark Excellent (6) into
            // a new anonymous class that has properties – FullName and Marks. Use LINQ.
            PrintTopStudetns(6.00m);

            // 14.Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
            PrintBottomStudetns(2.00m, 2);

            // 15. Extract all Marks of the students that enrolled in 2006.
            // The students from 2006 should have 06 as their 5-th and 6-th digit in the FN.
            PrintStudentsFromYear(2006);
        }

        private static void FillFaculty()
        {
            students = new List<Student>()
            {
                new Student("Johnny", "Walker", "johny@abv.bg", "359 2 886123456", 123406, 1, new List<decimal>() {6, 6, 6, 5.50m}), 
                new Student("Billy", "Bob", "billy@yahoo.com", "359 52 886184656", 223406, 2, new List<decimal>() {5, 5, 6, 4.50m}), 
                new Student("Jane", "Austin", "jane@gmail.com", "359 34 8453456", 263407, 2, new List<decimal>() {4, 4.5m, 4}), 
                new Student("Mery", "Jane", "mery@hotmail.com", "359 2 8128456", 723456, 7, new List<decimal>() {5, 4, 4}), 
                new Student("Tony", "M", "tony@yahoo.co.uk", "359 2 8887656", 523406, 5, new List<decimal>() {3, 2}), 
                new Student("Jack", "Sparrow", string.Empty, "359 56 88655956", 823409, 8, new List<decimal>() {2, 3, 2, 5, 6}), 
                new Student("Dean", "Donovan", "dean2014@abv.bg", "359 888356456", 263412, 2, new List<decimal>() {5.50m, 5.50m, 5.00m}), 
            };
        }

        // Select the students from a group number, ordered by FirstName. Use LINQ query.
        private static void PrintGroupLinq(int groupNumber)
        {
            var group = from student in students
                        where student.GroupNumber == groupNumber
                        orderby student.FristName
                        select student;

            Console.WriteLine("\nFrom group 2:");
            PrintStudents(group, student => student.GroupNumber.ToString());
        }

        // Select the students from a group number, ordered by FirstName. Use extension methods.
        private static void PrintGroupLambda(int groupNumber)
        {
            var group = students.Where(s => s.GroupNumber == groupNumber).OrderBy(s => s.FristName);

            Console.WriteLine("\nFrom group 2:");
            PrintStudents(group, student => student.GroupNumber.ToString());
        }

        // Extract all students that have a given email. Use string methods and LINQ.
        private static void PrintGroupEmail(string domain)
        {
            var group = from student in students
                        where student.Email.EndsWith(domain)
                        orderby student.FristName
                        select student;

            Console.WriteLine("\nWith emails in abv.bg:");
            PrintStudents(group, student => student.Email);
        }

        // Extract all students with phones in one city. Use LINQ.
        private static void PrintGroupPhones(string phone)
        {
            var group = from student in students
                        where student.Phone.StartsWith(phone)
                        orderby student.FristName
                        select student;

            Console.WriteLine("\nWith phones in Sofia:");
            PrintStudents(group, student => student.Phone);
        }

        // Select all students that have at least one mark Excellent (6) into
        // a new anonymous class that has properties – FullName and Marks. Use LINQ.
        private static void PrintTopStudetns(decimal mark)
        {
            var group = from student in students
                        where student.Marks.Contains(mark)
                        select new { FullName = student.ToString(), Marks = student.Marks };

            Console.WriteLine("\nTop students (at least one 6.00):");
            foreach (var student in group)
            {
                Console.WriteLine("FullName: {0} ({1})", student.FullName, string.Join(", ", student.Marks));
            }
        }

        // Extract the students with exactly two marks "2". Use extension methods.
        private static void PrintBottomStudetns(decimal mark, int count)
        {
            var group = students.Where(s => s.Marks.FindAll(m => m == mark).Count == count);

            Console.WriteLine("\nStudents with exactly two marks \"2\":");
            foreach (var student in group)
            {
                Console.WriteLine("{0} ({1})", student, string.Join(", ", student.Marks));
            }
        }

        // Extract all Marks of the students that enrolled in 2006.
        private static void PrintStudentsFromYear(uint year)
        {
            // TODO: PrintStudentsFromYear
            throw new NotImplementedException("PrintStudentsFromYear");
        }

        // Prints a group of students and one of their properties (passed by a delegate)
        private static void PrintStudents(IEnumerable<Student> students, Func<Student, string> property)
        {
            foreach (var student in students)
            {
                Console.WriteLine("{0} ({1})", student, property(student));
            }
        }

        // Print all student data
        private static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(
                    "{0,-13} [Group: {1, 1}, Email: {2, 16}, Phone: {3, 16}, Marks: {4, 16}]",
                    student,
                    student.GroupNumber,
                    student.Email,
                    student.Phone,
                    string.Join(", ", student.Marks));
            }
        }
    }
}