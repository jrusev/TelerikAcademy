namespace GeometryAPI
{
    using System;

    public class Cylinder : Figure, IVolumeMeasurable, IAreaMeasurable
    {
        // (bottomX,bottomY,bottomZ) (topX, topY, topZ) radius 
        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            : base(bottom, top)
        {
            this.Bottom = bottom;
            this.Top = top;
            this.Radius = radius;
        }

        public Vector3D Bottom { get; private set; }

        public Vector3D Top { get; private set; }

        public double Radius { get; private set; }

        public double Height
        { 
            get
            {
                return this.Top.Z - this.Bottom.Z;
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
            return 2 * Math.PI * this.Radius * this.Height;
        }
    }
}
