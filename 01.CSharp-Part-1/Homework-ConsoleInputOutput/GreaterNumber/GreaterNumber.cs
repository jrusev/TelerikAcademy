using System;

class GreaterNumber
{
    static void Main()
    {
        // Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

        Console.Write("First number = ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Second number = ");
        double num2 = double.Parse(Console.ReadLine());

        // the problem requires not to use "if statements" rather than conditional statements, so we can use the ternary operator ?:
        Console.WriteLine("The greater of the two numbers is {0}.", (num1 > num2) ? num1 : num2);
        // still there is a problem if the numbers are equal, this will require a conditional statement
    }
}