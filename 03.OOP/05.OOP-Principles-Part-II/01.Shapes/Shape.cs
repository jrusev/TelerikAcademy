namespace Shapes
{
    using System;

    // Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    public abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            { 
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Dimensions cannot be negative!");
                }

                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            { 
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Dimensions cannot be negative!");
                }

                this.height = value;
            }
        }

        public abstract double CalculateSurface();

        public abstract override string ToString();
    }
}
