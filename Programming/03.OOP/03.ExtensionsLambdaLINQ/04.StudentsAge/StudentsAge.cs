using System;
using System.Collections.Generic;
using System.Linq;
using Students;

internal class StudentsAge
{
    // Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
    private static void Main()
    {
        var students = new Student[5]
        {
            new Student("Ivo", "Georgiev", 17),
            new Student("Ani", "Zlateva", 24),
            new Student("Mitio", "Krika", 19),
            new Student("Johnny", "Bravo", 28),
            new Student("Super", "Man", 23),
        };

        // Print the students
        Console.WriteLine("All students:");
        PrintStudents(students);

        // Finds all students with age between 18 and 24
        var shortList = from student in students
                        where student.Age >= 18 && student.Age <= 24
                        orderby student.Age
                        select student;

        // Print the result from the query
        Console.WriteLine("\nStudents with age between 18 and 24:");
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