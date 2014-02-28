using System;

internal class Program
{
    internal static void Main()
    {
        // Task 1: 
        // Define a class Student, which contains data about a student.
        // Override the standard methods, inherited by  System.Object:
        // Equals(), ToString(), GetHashCode() and operators == and !=.
        Student stu1 = new Student("Billy", "Bob", 2939025702, University.Stanford, Faculty.Engineering, Specialty.ComputerScience);
        Student stu2 = new Student("John", "Chambers", 6536025741, University.Harvard, Faculty.Business, Specialty.Management);

        Console.WriteLine("stu1: {0}", stu1);
        Console.WriteLine("stu2: {0}", stu2);

        Console.WriteLine("stu1 hash code: {0}", stu1.GetHashCode());
        Console.WriteLine("stu2 hash code: {0}", stu2.GetHashCode());

        Console.WriteLine("stu1 == stu2 -> {0}", stu1 == stu2);
        Console.WriteLine("stu1 != stu2 -> {0}", stu1 != stu2);
        Console.WriteLine("stu1.Equals(stu2) -> {0}", stu1.Equals(stu2));

        // Task 2: Clone
        Student stu3 = (Student)stu1.Clone();
        Console.WriteLine("stu1 clone: {0}", stu3);

        // Task 3: Compare
        Console.WriteLine("stu1 > stu2 -> {0}", stu1.CompareTo(stu2));
        Console.WriteLine("stu1 > stu3 -> {0}", stu1.CompareTo(stu3));
    }
}