using System;

class TriangleSurface
{
    static void Main()
    {
        // Write methods that calculate the surface of a triangle by given:
        // Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

        Console.WriteLine("This program calculates the surface of a triangle by:");

        Console.WriteLine("1) Side and an altitude to it");
        Console.WriteLine("2) Three sides");
        Console.WriteLine("3) Two sides and an angle between them");

        Console.Write("Please make a selection (1-3): ");
        ConsoleKey choice = Console.ReadKey().Key;
        switch (choice)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                TriangleAreaBySideAlt(); // Side and an altitude to it
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                TriangleAreaByThreeSides(); // Three sides
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                TriangleAreaBySidesAngle(); // Two sides and an angle between them
                break;
            default:
                Console.WriteLine("Thank you!");
                break;
        }
    }

    // Side and an altitude to it
    static void TriangleAreaBySideAlt()
    {
        Console.Clear();
        Console.WriteLine("Surface of a triangle by side and an altitude to it.");
        Console.Write("side = ");
        double side = double.Parse(Console.ReadLine());
        Console.Write("altitide = ");
        double altitude = double.Parse(Console.ReadLine());

        double surface = side * altitude / 2;

        Console.WriteLine("surface = {0:F2}", surface);
    }

    // Three sides
    static void TriangleAreaByThreeSides()
    {
        Console.Clear();
        Console.WriteLine("Surface of a triangle by three sides.");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        // Check whether a, b, c can form a triangle
        if (a + b > c && a + c > b && b + c > a)
        {
            double p = (a + b + c) / 2; // semi perimeter
            double surface = Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // Heron's formula

            Console.WriteLine("surface = {0:F2}", surface);
        }
        else
        {
            Console.WriteLine("This is not a triangle because sum of two sides is not greater than the third side.");
        }
    }

    // Two sides and an angle between them
    static void TriangleAreaBySidesAngle()
    {
        Console.Clear();
        Console.WriteLine("Two sides and an angle between them.");
        Console.Write("side a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("side b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("angle C = ");
        double angle = double.Parse(Console.ReadLine());

        if (angle <= 0 || angle >= 180)
        {
            Console.WriteLine("The angle must be between 0 and 180.");
        }
        else
        {
            double angleRad = angle * Math.PI / 180; // Convert to radians first
            double surface = a * b * Math.Sin(angleRad) / 2;
            Console.WriteLine("surface = {0:F2}", surface);
        }
    }
}