using System;
using School;

internal class Program
{
    private static void Main()
    {
        // It's interesting to test the child classes of Person...
        // The Teacher class inherits the Name property from Person
        Teacher guy = new Teacher("Nakov");
        Console.WriteLine(guy.Name); // Invokes the Person Name property

        // Class Student overrides the Name property of its base class Person
        Person stu = new Student(string.Empty); // Invokes the Student Name property
        Console.WriteLine(stu.Name); // Invokes the Student Name property

        // The following will cause compiler error because Person is declared as abstract:
        ////var human = new Person("Homo Sapiens");
    }
}