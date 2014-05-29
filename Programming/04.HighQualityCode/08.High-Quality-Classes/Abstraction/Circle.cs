namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                this.ThrowIfNegative(value, "radius");
                this.radius = value;
            }
        }

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
