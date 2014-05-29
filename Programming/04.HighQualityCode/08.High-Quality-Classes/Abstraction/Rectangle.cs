namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public override double Perimeter
        {
            get
            {
                double perimeter = 2 * (this.Width + this.Height);
                return perimeter;
            }
        }

        public override double Area
        {
            get
            {
                double surface = this.Width * this.Height;
                return surface;
            }
        }
    }
}
