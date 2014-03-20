using System;

class RectangleArea
{
    static void Main()
    {
        // Write an expression that calculates rectangle’s area by given width and height.
        Console.Write("Please enter width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("\nNow enter height: ");
        double height = double.Parse(Console.ReadLine());
        double area = width * height;
        Console.WriteLine("\nThe area of a rectangle with height {0} and width {1} is {2}.", height, width, area);
    }
}