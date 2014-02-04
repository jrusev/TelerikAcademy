namespace Space3D
{
    using System;

    // Write a static class with a static method to calculate the distance between two points in the 3D space.
    public static class Distance3D
    {
        public static double CalcDistance(Point3D pA, Point3D pB)
        {
            if (pA.X == pB.X && pA.Y == pB.Y && pA.Z == pB.Z)
            {
                return 0;
            }

            double diffX = pA.X - pB.X;
            double diffY = pA.Y - pB.Y;
            double diffZ = pA.Z - pB.Z;
            double distance = Math.Sqrt((diffX * diffX) + (diffY * diffY) + (diffZ * diffZ));
            return distance;
        }
    }
}
