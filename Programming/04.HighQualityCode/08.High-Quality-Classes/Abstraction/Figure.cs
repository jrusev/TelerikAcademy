namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public Figure()
        {
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width { get; private set; }

        public virtual double Height { get; private set; }
    }
}
