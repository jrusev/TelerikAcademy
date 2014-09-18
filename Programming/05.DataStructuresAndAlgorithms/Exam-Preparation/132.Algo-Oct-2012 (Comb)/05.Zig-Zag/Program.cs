using System;

// http://bgcoder.com/Contests/Practice/Index/132#4
class Program
{
    static int count = 0;

    static void Main()
    {
        var nk = Console.ReadLine().Split(' ');
        int n = int.Parse(nk[0]);
        int k = int.Parse(nk[1]);

        Variate(0, n, k, -1, new bool[n]);
        Console.WriteLine(count);
    }

    private static void Variate(int p, int n, int k, int prev, bool[] used)
    {
        if (p == k)
        {
            count++;
            return;
        }

        if (p % 2 == 0)
        {
            for (int i = prev + 1; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    Variate(p + 1, n, k, i, used);
                    used[i] = false;
                }
            }
        }
        else if (p % 2 != 0)
        {
            for (int i = prev - 1; i >= 0; i--)
            {
                if (!used[i])
                {
                    used[i] = true;
                    Variate(p + 1, n, k, i, used);
                    used[i] = false;
                }
            }
        }
    }
}
