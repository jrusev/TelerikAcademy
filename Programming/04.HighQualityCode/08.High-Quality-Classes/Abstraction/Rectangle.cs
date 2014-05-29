namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width 
        { 
            get
            {
                return this.width;
            }

            private set
            {
                this.ThrowIfNegative(value, "width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                this.ThrowIfNegative(value, "height");
                this.height = value;
            }
        }

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
