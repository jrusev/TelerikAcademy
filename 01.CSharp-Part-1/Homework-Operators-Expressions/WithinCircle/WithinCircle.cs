using System;

class WithinCircle
{
    static void Main()
    {
        // Write an expression that checks if given point (x,  y) is within a circle K(O, 5).
        float circleRadius = 5;

        Console.WriteLine("Please enter coordinates of the point:");
        Console.Write("x = ");
        float x = float.Parse(Console.ReadLine());
        Console.Write("y = ");
        float y = float.Parse(Console.ReadLine());

        float pointRadius = (float)Math.Sqrt(x * x + y * y); // the distance from the center of the circle to the point
        bool inCircle = (pointRadius <= circleRadius);

        if (inCircle)
        {
            Console.WriteLine("The point ({0},{1}) is within the circle K(0,5)", x, y);
        }
        else
        {
            Console.WriteLine("The point ({0},{1}) is not within the circle K(0,5)", x, y);
        }
    }
}