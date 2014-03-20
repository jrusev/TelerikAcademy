namespace Space3D
{
    using System;

    public class Program
    {
        // Save and load paths in 3D space from a text file
        public static void Main()
        {
            // Create 3 points in space
            Point3D p1 = new Point3D(2, 3, 4);
            Point3D p2 = new Point3D(5, 6, 7);
            Point3D p3 = new Point3D(8, 9, 0);

            // Create a path from the points
            Path3D pathSave = new Path3D(p1, p2, p3);

            // Print the path
            Console.WriteLine(@"Path in 3D space to save to file (...\...\path.txt):");
            pathSave.PrintPath();

            // Save the path to a file
            string file = @"...\...\path.txt";
            Path3dStorage.SavePathToFile(pathSave, file);

            // Load the path from the file
            Path3D pathLoad = Path3dStorage.LoadPathFromFile(file);

            // Print the loaded path
            Console.WriteLine();
            Console.WriteLine(@"Path in 3D space loaded from file (...\...\path.txt):");
            pathLoad.PrintPath();

            // Calculate the distance between two points in the 3D space.
            double p1p2 = Distance3D.CalcDistance(p1, p2);
            Console.WriteLine("\nDistance between p{0} and p{1}: {2:F2}", p1, p2, p1p2);
        }
    }
}
