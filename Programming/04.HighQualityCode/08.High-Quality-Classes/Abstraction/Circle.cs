namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public double Perimeter
        {
            get
            {
                double perimeter = 2 * Math.PI * this.Radius;
                return perimeter;
            }
        }

        public double Surface
        {
            get
            {
                double surface = Math.PI * this.Radius * this.Radius;
                return surface;
            }
        }
    }
}
