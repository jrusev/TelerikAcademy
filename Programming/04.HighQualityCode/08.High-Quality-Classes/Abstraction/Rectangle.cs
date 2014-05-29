namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public double Perimeter
        {
            get
            {
                double perimeter = 2 * (this.Width + this.Height);
                return perimeter;
            }
        }

        public double Surface
        {
            get
            {
                double surface = this.Width * this.Height;
                return surface;
            }
        }
    }
}
