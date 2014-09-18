using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Frames
{
    static IList<int[]> frames;
    static int[][] perm;
    static bool[] used;
    static int count = 0;
    static IList<string> allPerms = new List<string>();

    const string Test001 = @"3
2 3
2 2
3 2
";

    internal static void MainSlow()
    {
        // Sets the Console to read from string
        //Console.SetIn(new StringReader(Test001));

        int n = int.Parse(Console.ReadLine());
        frames = new List<int[]>(n);
        perm = new int[n][];
        used = new bool[n];
        for (int i = 0; i < n; i++)
        {
            var frame = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            if (frame.Length != 2)
            {
                throw new ArgumentException("Frames must have two dimensions!");
            }
            frames.Add(frame);
        }

        frames = frames.OrderBy(f => f[0]).ThenBy(f => f[1]).ToList();

        Permutate(0, n);
        Console.WriteLine(count);
        Console.WriteLine(string.Join(Environment.NewLine, allPerms.OrderBy(f => f)));
    }

    private static void Permutate(int p, int n)
    {
        if (p == n)
        {
            allPerms.Add(string.Format("{0}", string.Join(" | ", perm.Select(f => string.Format("({0}, {1})", f[0], f[1])))));
            count++;
            return;
        }

        perm[p] = new int[] { int.MinValue, int.MinValue };
        for (int i = 0; i < n; i++)
        {
            var frame = frames[i];
            int min = Math.Min(frame[0], frame[1]);
            int max = Math.Max(frame[0], frame[1]);
            frame = new int[] { min, max };

            if (!used[i] && IsGreater(frame, perm[p]))
            {
                used[i] = true;
                perm[p] = frame;
                Permutate(p + 1, n);
                used[i] = false;

                if (min != max)
                {
                    frame = new int[] { max, min };
                    used[i] = true;
                    perm[p] = frame;
                    Permutate(p + 1, n);
                    used[i] = false;
                }

                perm[p] = frames[i];
            }
        }
    }

    private static bool IsGreater(int[] a, int[] b)
    {
        return a[0] > b[0] ? true : a[0] == b[0] ? a[1] > b[1] : false;
    }
}

