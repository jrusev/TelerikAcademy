namespace CohesionAndCoupling
{
    using System;

    public class Test
    {
        public static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("-------------------------");

            Console.WriteLine("Distance in the 2D space = {0:f2}", GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine("-------------------------");

            var cubo = new Cuboid(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", cubo.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", cubo.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", cubo.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", cubo.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", cubo.CalcDiagonalYZ());
        }
    }
}
