namespace GeometryAPI
{
    using System;

    public class Circle : Figure, IAreaMeasurable, IFlat
    {
        public Circle(Vector3D center, double radius)
            : base(center)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }

        public double GetArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public Vector3D GetNormal()
        {
            // Circles will always lay in the XY plane
            return new Vector3D(0, 0, 1);
        }
    }
}