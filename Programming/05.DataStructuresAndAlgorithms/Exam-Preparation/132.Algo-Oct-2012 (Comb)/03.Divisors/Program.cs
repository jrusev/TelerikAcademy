using System;
using System.IO;

// http://bgcoder.com/Contests/Practice/Index/132#2
class Program
{
    static int[] digits;
    static int minDivisors = int.MaxValue;
    static int sol;
    const string Test001 = @"5
9
8
7
6
5
";

    static void Main()
    {
        //Console.SetIn(new StringReader(Test001));

        int n = int.Parse(Console.ReadLine());
        digits = new int[n];
        for (int i = 0; i < n; i++)
        {
            digits[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(digits); // ensure the permutations are in ascending order
        Permutate(0, n, new int[n], new bool[n]);
        Console.WriteLine(sol);
    }

    private static void Permutate(int p, int n, int[] arr, bool[] used)
    {
        if (p == n)
        {
            int num = int.Parse(string.Join("", arr));
            FindDivisors(num);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (!used[i])
            {
                arr[p] = digits[i];
                used[i] = true;
                Permutate(p + 1, n, arr, used);
                used[i] = false;
            }
        }
    }

    private static void FindDivisors(int num)
    {
        int count = GetFactorCount(num);
        if (count < minDivisors)
        {
            minDivisors = count;
            sol = num;
        }
    }

    public static int GetFactorCount(int numberToCheck)
    {
        int factorCount = 0;
        int sqrt = (int)Math.Ceiling(Math.Sqrt(numberToCheck));

        for (int i = 1; i < sqrt; i++)
        {
            if (numberToCheck % i == 0)
            {
                factorCount += 2; //  We found a pair of factors.
            }
        }

        if (sqrt * sqrt == numberToCheck)
        {
            factorCount++;
        }

        return factorCount;
    }
}

