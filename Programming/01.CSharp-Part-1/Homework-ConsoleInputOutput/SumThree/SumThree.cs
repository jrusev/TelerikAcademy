using System;

class SumThree
{
    static void Main()
    {
        // Write a program that reads 3 integer numbers from the console and prints their sum.
        Console.Write("Enter first integer: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter second integer: ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Write("Enter third integer: ");
        int num3 = int.Parse(Console.ReadLine());
        Console.WriteLine("{0} + {1} + {2} = {3}",num1, num2, num3, num1 + num2 + num3);
    }
}