using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    // Create a class Person with two fields – name and age.
    // Age can be left unspecified (may contain null value.
    // Override ToString() to display the information of a person and if age is not specified – to say so.
    // Write a program to test this functionality.
    internal static void Main()
    {
        Person p1 = new Person("Johny");
        Person p2 = new Person("Tonny", null);
        Person p3 = new Person("Billy", 23);

        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p3);
    }
}