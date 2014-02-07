using System;
using System.Collections.Generic;
using System.Linq;
using Students;

internal class StudentsLINQ
{
    // Write a method that from a given array of students finds all students
    // whose first name is before its last name alphabetically. Use LINQ query operators.
    private static void Main()
    {
        var students = new Student[5]
        {
            new Student("Ivo", "Georgiev"),
            new Student("Ani", "Zlateva"),
            new Student("Mitio", "Krika"),
            new Student("Johnny", "Bravo"),
            new Student("Super", "Man"),
        };

        // Print the students
        Console.WriteLine("All students:");
        PrintStudents(students);

        // Finds all students whose first name is before its last name alphabetically
        var shortList = from student in students
                        where student.FristName.CompareTo(student.LastName) < 0
                        select student;

        // Print the result from the query
        Console.WriteLine("\nStudents whose first name is before its last name alphabetically:");
        PrintStudents(shortList);
    }

    // Prints a list of students
    private static void PrintStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine("  " + student);
        }
    }
}