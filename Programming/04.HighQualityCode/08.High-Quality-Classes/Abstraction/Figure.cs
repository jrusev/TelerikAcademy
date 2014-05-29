using System;

namespace Abstraction
{
    public abstract class Figure
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        public Figure()
        {
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
