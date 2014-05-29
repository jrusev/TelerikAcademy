namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public abstract double Area { get; }

        public abstract double Perimeter { get; }

        public override string ToString()
        {
            return string.Format(
                "I am a {0}. " + "My perimeter is {1:f2}. My surface is {2:f2}.",
                this.GetType().Name,
                this.Perimeter,
                this.Area);
        }

        protected void ThrowIfNegative(double param, string paramName)
        {
            if (param <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "Value must be positive, got " + param);
            }
        }
    }
}
