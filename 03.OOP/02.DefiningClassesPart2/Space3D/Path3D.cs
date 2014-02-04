namespace Space3D
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // Create a class Path to hold a sequence of points in the 3D space.
    public class Path3D : IEnumerable
    {
        private List<Point3D> path;

        public Path3D()
        {
            this.Path = new List<Point3D>();
        }

        public Path3D(params Point3D[] path)
        {
            this.Path = new List<Point3D>(path);
        }

        public List<Point3D> Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public void AddPoint(Point3D point)
        {
            this.Path.Add(point);
        }

        public IEnumerator GetEnumerator()
        {
            return this.Path.GetEnumerator();
        }

        public void PrintPath()
        {
            foreach (var point in this.Path)
            {
                Console.WriteLine(point);
            }
        }
    }
}
