using System;
using System.Linq;

class Program
{
    static int[] p;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        p = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int minDiff = int.Parse(Console.ReadLine());

        if (Math.Abs(p.Max() - p.Min()) < minDiff)
        {
            Console.WriteLine(n);
            return;
        }

        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            int j = FindTarget(i, minDiff);
            int hops = DistBetween(0, i) + DistBetween(i, j) + 1;
            min = Math.Min(min, hops);
        }

        Console.WriteLine(min);
    }

    private static int FindTarget(int from, int minDiff)
    {
        for (int i = from; i < p.Length; i++)
        {
            if (Math.Abs(p[i] - p[from]) >= minDiff)
            {
                return i;
            }
        }

        return p.Length - 1;
    }

    private static int DistBetween(int from, int to)
    {
        var dist = to - from;
        int hops = (dist / 2) + (dist % 2);
        return hops ;
    }
}
