using System;
using System.Collections.Generic;
using System.Linq;
using Students;

internal class StudentsOrderBy
{
    // Using the extension methods OrderBy() and ThenBy() with lambda expressions
    // sort the students by first name and last name in descending order.
    // Rewrite the same with LINQ.
    private static void Main()
    {
        var students = new Student[5]
        {
            new Student("Ivo", "Georgiev"),
            new Student("Ani", "Zlateva"),
            new Student("Ivo", "Antonov"),
            new Student("Johnny", "Bravo"),
            new Student("Super", "Man"),
        };

        // Print the students
        Console.WriteLine("Unsorted:");
        PrintStudents(students);

        // Sort by first name and last name using extension methods and lambda expressions
        var sortedByMethods = students.OrderBy(student => student.FristName).ThenBy(student => student.LastName);

        // Print the sorted list
        Console.WriteLine("\nSorted using LINQ method syntax:");
        PrintStudents(sortedByMethods);

        // Sort by first name and last name using LINQ query
        var sortedByQuery = from student in students
                           orderby student.FristName, student.LastName
                           select student;

        // Print the sorted list
        Console.WriteLine("\nSorted using LINQ query syntax:");
        PrintStudents(sortedByQuery);
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
