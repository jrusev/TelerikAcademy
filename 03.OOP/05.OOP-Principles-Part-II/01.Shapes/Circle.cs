namespace Shapes
{
    using System;

    // Define class Circle and suitable constructor so that at initialization height
    // must be kept equal to width and implement the CalculateSurface() method. 
    public class Circle : Shape
    {
        // Initialization height must be kept equal to width 
        public Circle(double radius)
            : base(radius * 2, radius * 2)
        {
        }

        public override double CalculateSurface()
        {
            // width = height = diameter = 2 * R
            return Math.PI * Math.Pow(this.Height / 2, 2);
        }

        public override string ToString()
        {
            return "Circle";
        }
    }
}