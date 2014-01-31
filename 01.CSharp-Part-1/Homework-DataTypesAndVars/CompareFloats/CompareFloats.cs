using System;

class CompareFloats
{
    static void Main()
    {
        // Write a program that safely compares floating-point numbers with precision of 0.000001.
        // Examples: (5.3 ; 6.01) is false;  (5.00000001 ; 5.00000003) is true

        Console.WriteLine("Please enter two real numbers.");

        // use type decimal because we want decimal point precision
        Console.Write("a = ");
        decimal a = decimal.Parse(Console.ReadLine());
        Console.Write("b = ");
        decimal b = decimal.Parse(Console.ReadLine());

        //Console.WriteLine(a - b);

        Console.WriteLine("a = b is {0}!", Math.Abs(a - b) <= 0.000001m);
    }
}