using System;

class GetMaxThree
{
    static void Main()
    {
        // Write a method GetMax() with two parameters that returns the bigger of two integers.
        // Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

        Console.WriteLine("Please enter three integers:");

        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("c = ");
        int c = int.Parse(Console.ReadLine());

        int biggest = GetMax(a, GetMax(b, c));
        Console.WriteLine("The biggest number is {0}.",biggest);
    }

    static int GetMax(int a, int b)
    {
        if (a > b) return a;
        else return b;
    }
}