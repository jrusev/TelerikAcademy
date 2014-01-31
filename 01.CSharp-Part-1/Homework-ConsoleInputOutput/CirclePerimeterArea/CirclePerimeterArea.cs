using System;

class CirclePerimeterArea
{
    static void Main()
    {
        // Write a program that reads the radius r of a circle and prints its perimeter and area.
        Console.Write("Enter the radius of the circle: ");
        float radius = float.Parse(Console.ReadLine());
        Console.WriteLine("Perimeter = {0:F2}", 2 * Math.PI * radius);
        Console.WriteLine("Area = {0:F2}", Math.PI * radius * radius);
    }
}