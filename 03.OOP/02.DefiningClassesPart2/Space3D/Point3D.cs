namespace Space3D
{
    // Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
    public struct Point3D
    {
        // Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
        private static readonly Point3D Center = new Point3D(0, 0, 0);

        // Constructor
        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Add a static property to return the point O.
        public static Point3D PointO
        {
            get { return Point3D.Center; }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        // Implement the ToString() to enable printing a 3D point.
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
        }
    }
}