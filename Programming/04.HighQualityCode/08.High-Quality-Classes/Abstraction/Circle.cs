namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public override double Perimeter
        {
            get
            {
                double perimeter = 2 * Math.PI * this.Radius;
                return perimeter;
            }
        }

        public override double Area
        {
            get
            {
                double surface = Math.PI * this.Radius * this.Radius;
                return surface;
            }
        }
    }
}
