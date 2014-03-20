namespace Space3D
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    // Create a static class PathStorage with static methods to save and load paths from a text file.
    // Use a file format of your choice.
    public static class Path3dStorage
    {
        private static readonly char[] Separators = new char[] { '(', ')', ',', ' ' };

        public static void SavePathToFile(Path3D path3D, string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (var point in path3D)
                {
                    writer.WriteLine(point);
                }
            }
        }

        public static Path3D LoadPathFromFile(string file)
        {
            List<string> fileLines = new List<string>();
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    fileLines.Add(line);
                }
            }

            if (fileLines.Count == 0)
            {
                throw new ApplicationException("File is empty!");
            }

            return ParsePath(fileLines);
        }

        /// <summary>
        /// Reads a list of lines which contain points in 3D space and adds them to a path.
        /// </summary>
        /// <param name="fileLines">The list of lines.</param>
        /// <returns>Returns the path as a list of points.</returns>
        private static Path3D ParsePath(List<string> fileLines)
        {
            Path3D path = new Path3D();

            // string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
            foreach (var line in fileLines)
            {
                double[] coord = line.Split(Separators, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();
                Point3D pt = new Point3D(coord[0], coord[1], coord[2]);
                path.AddPoint(pt);
            }

            return path;
        }
    }
}
