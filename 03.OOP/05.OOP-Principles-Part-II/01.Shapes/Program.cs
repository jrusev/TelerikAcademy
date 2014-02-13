namespace Shapes
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        // Write a program that tests the behavior of  the CalculateSurface() method
        // for different shapes (Circle, Rectangle, Triangle) stored in an array.
        private static void Main()
        {
            var shapes = new List<Shape>()
            {
                new Rectangle(2.3, 5),
                ////new Rectangle(-2, 4),
                new Triangle(3, 5),
                new Circle(2.5),
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0} [{1} x {2}], area = {3:F2}", shape, shape.Width, shape.Height, shape.CalculateSurface());
            }
        }
    }
}