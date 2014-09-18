using System;
using System.Linq;

class Program
{
    static bool[,] cache = new bool[50 + 1, 1000 + 1];
    static int maxLevel = -1;

    static void Main()
    {
        int numChanges = int.Parse(Console.ReadLine());
        var changes = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int startLevel = int.Parse(Console.ReadLine());
        int maxLevel = int.Parse(Console.ReadLine());

        FindMaxDP(0, changes, maxLevel, startLevel);
        //FindMaxRecurse(0, changes, maxLevel, startLevel);        
        //Console.WriteLine(maxLevel);
    }

    private static void FindMaxRecurse(int p, int[] changes, int maxLevel, int current)
    {
        if (cache[p, current])
            return;

        cache[p, current] = true;

        if (p == changes.Length)
        {
            maxLevel = Math.Max(maxLevel, current);
            return;
        }

        if (current + changes[p] <= maxLevel)
            FindMaxRecurse(p + 1, changes, maxLevel, current + changes[p]);

        if (current - changes[p] >= 0)
            FindMaxRecurse(p + 1, changes, maxLevel, current - changes[p]);
    }

    private static void FindMaxDP(int p, int[] changes, int maxLevel, int startLevel)
    {
        int n = changes.Length;
        var dp = new bool[n + 1, maxLevel + 1];

        dp[0, startLevel] = true;
        for (int i = 1; i <= n; i++)
        {
            int change = changes[i - 1];
            for (int level = 0; level <= maxLevel; level++)
            {
                if (dp[i - 1, level])
                {                    
                    if (level + change <= maxLevel)
                    {
                        dp[i, level + change] = true;
                    }
                    if (level - change >= 0)
                    {
                        dp[i, level - change] = true;
                    }
                }
            }
        }

        int maxFinal = -1;
        for (int level = maxLevel; level >= 0; level--)
        {
            if (dp[n, level])
            {
                maxFinal = level;
                break;
            }
        }

        Console.WriteLine(maxFinal);

        //PrintTable(table);
    }

    private static void PrintTable(bool[,] d)
    {
        for (int row = 0; row < d.GetLength(0); row++)
        {
            for (int col = 0; col < d.GetLength(1); col++)
            {
                Console.Write("{0,2}", d[row, col] ? 1 : 0);
            }
            Console.WriteLine();
        }
    }
}
