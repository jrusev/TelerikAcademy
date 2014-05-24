using System;

public class Program
{
    public static void Main()
    {
        var size = new Size(3, 4);        
        double angleDegr = 90;
        double angleRads = angleDegr * Math.PI / 180;
        var rotated = RotateSize(size, angleRads);

        Console.WriteLine(size);
        Console.WriteLine("Rotate by {0} degrees:", angleDegr);
        Console.WriteLine(rotated);
    }

    public static Size RotateSize(Size size, double rotationRads)
    {
        double width = Math.Abs(Math.Cos(rotationRads) * size.Width) + Math.Abs(Math.Sin(rotationRads) * size.Height);
        double height = Math.Abs(Math.Sin(rotationRads) * size.Width) + Math.Abs(Math.Cos(rotationRads) * size.Height);
        var rotated = new Size(width, height);
        return rotated;
    }
}