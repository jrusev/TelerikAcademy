using System;
using System.Linq;

// 16. Oringal task:
// Create a class Group with properties GroupNumber and DepartmentName.
// Introduce a property Group in the Student class.
// Extract all students from "Mathematics" department. Use the Join operator.
//
// 16. Corrected task:
// Create a class Department with properties Name and ID.
// Introduce a property DepartmentID in the Student class.
// Extract all students from "Mathematics" department. Use the Join operator.
//
// 18. Create a program that extracts all students grouped by department and then prints them to the console. Use LINQ.
// 19. Rewrite the previous using extension methods.
public class Department
{
    public Department(string name, string id)
    {
        this.Name = name;
        this.ID = id;
    }

    public string Name { get; set; }

    public string ID { get; set; }
}

public class Student
{
    public Student(string name, string depID)
    {
        this.Name = name;
        this.DepartmentID = depID;
    }

    public string Name { get; set; }

    public string DepartmentID { get; set; }
}

internal class Program
{
    private static void Main()
    {
        // Create students
        var students = new Student[]
        {
            new Student("Nakov", "5018"),
            new Student("Stephen Hawking", "5513"),
            new Student("John Nash", "6012"),
            new Student("Niki", "5018"),
            new Student("Joro", "5018"),
            new Student("Will Hunting", "6012"),
        };

        // Create departments
        var departments = new Department[]
        { 
            new Department("Mathematics", "6012"),
            new Department("Physics", "5513"),
            new Department("CompSci", "5018")
        };

        // Extract all students grouped by department (Task 18)
        // Create a list of Department-Student pairs where  
        // each element is an anonymous type that contains a 
        // Student's name and the name of the Department where the Student is enrolled. 
        var studentsByDep =
            from department in departments
            join student in students on department.ID equals student.DepartmentID
            select new { Department = department.Name, Student = student.Name };

        // Same as above using extension methods (Task 19)
        var query =
            departments.Join(students,
                        department => department.ID,
                        student => student.DepartmentID,
                        (department, student) =>
                            new { Department = department.Name, Student = student.Name });

        // Print the list (unsorted)
        Console.WriteLine("{0, -15} : {1}", "Student Name", "Department");
        Console.WriteLine("{0, -15} : {1}", "============", "==========");
        foreach (var item in studentsByDep)
        {
            Console.WriteLine("{0, -15} : {1}", item.Student, item.Department);
        }

        // Sort by department and student name
        var departmentGroups = studentsByDep.OrderBy(x => x.Department).ThenBy(x => x.Student);

        Console.WriteLine("\n{0, -15} : {1}", "Department", "Student Name");
        Console.WriteLine("{0, -15} : {1}", "==========", "============");
        foreach (var item in departmentGroups)
        {
            Console.WriteLine("{0, -15} : {1}", item.Department, item.Student);
        }

        // Only the math students (Task 16)
        var mathStudents = studentsByDep.Where(x => x.Department == "Mathematics").OrderBy(x => x.Student);

        Console.WriteLine();
        Console.WriteLine("\nMathematics");
        Console.WriteLine("===========");
        foreach (var item in mathStudents)
        {
            Console.WriteLine(item.Student);
        }
    }
}