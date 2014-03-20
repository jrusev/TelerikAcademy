using System;

class QuadraticEquation
{
    static void Main()
    {
        /*
         * Write a program that enters the coefficients a, b and c of a quadratic equation { ax2 + bx + c = 0 }
         * and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
         * For example a = 2, b = 4, c = -30 => x1 = 3, x2 = -5
         * a = 2, b = 4, c = 2 => x1 = x2 = -1
         */

        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        double D = (b * b) - (4 * a * c);
        double x1, x2;

        if (D < 0)
        {
            Console.WriteLine("The equation has no real roots.");
        }
        else if (D == 0)
        {
            x1 = -b / (2 * a);
            Console.WriteLine("The equation has one real root x = {0}.", x1);
        }
        else
        {
            x1 = (-b + Math.Sqrt(D)) / (2 * a);
            x2 = (-b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine("The real roots are x1 = {0} and x2 = {1}.", x1, x2);
        }
    }
}