//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Telerik Academy">
//     Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
// <summary>Test for the Size class.</summary>
//-----------------------------------------------------------------------
using System;

/// <summary>
/// A class which demonstrates the use of the <see cref="Size"/> class.
/// </summary>
public class Program
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
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

    /// <summary>
    /// Rotates a shape with given width and height.
    /// </summary>
    /// <param name="size">The <see cref="Size"/> to rotate.</param>
    /// <param name="rotationRads">The degree of rotation in radians.</param>
    /// <returns>The dimension of the shape after rotation.</returns>
    public static Size RotateSize(Size size, double rotationRads)
    {
        double width = Math.Abs(Math.Cos(rotationRads) * size.Width) + Math.Abs(Math.Sin(rotationRads) * size.Height);
        double height = Math.Abs(Math.Sin(rotationRads) * size.Width) + Math.Abs(Math.Cos(rotationRads) * size.Height);
        var rotated = new Size(width, height);
        return rotated;
    }
}