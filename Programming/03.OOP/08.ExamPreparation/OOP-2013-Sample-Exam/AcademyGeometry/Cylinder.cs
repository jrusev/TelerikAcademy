namespace GeometryAPI
{
    using System;

    public class Cylinder : Figure, IVolumeMeasurable, IAreaMeasurable
    {
        // (bottomX,bottomY,bottomZ) (topX, topY, topZ) radius 
        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            : base(bottom, top)
        {
            this.Radius = radius;
        }

        public Vector3D Top
        {
            get
            {
                return new Vector3D(this.vertices[0].X, this.vertices[0].Y, this.vertices[0].Z);
            }

            private set
            {
                this.vertices[0] = new Vector3D(value.X, value.Y, value.Z);
            }
        }

        public Vector3D Bottom
        {
            get
            {
                return new Vector3D(this.vertices[1].X, this.vertices[1].Y, this.vertices[1].Z);
            }

            private set
            {
                this.vertices[1] = new Vector3D(value.X, value.Y, value.Z);
            }
        }

        public double Radius { get; private set; }

        public double Height
        {
            get
            {
                return (this.Top - this.Bottom).Magnitude;
            }
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }

        public double GetVolume()
        {
            return Math.PI * this.Radius * this.Radius * this.Height;
        }

        public double GetArea()
        {
            return (2 * Math.PI * this.Radius * this.Radius) + (2 * Math.PI * this.Radius * this.Height);
        }
    }
}