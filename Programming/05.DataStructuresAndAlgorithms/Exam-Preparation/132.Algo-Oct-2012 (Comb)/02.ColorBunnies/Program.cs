using System;
using System.Collections.Generic;
using System.Linq;

// http://bgcoder.com/Contests/Practice/Index/132#1
class Program
{
    static void Main()
    {
        var dict = new Dictionary<int, int>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int answer = int.Parse(Console.ReadLine()) + 1;
            int count;
            dict[answer] = dict.TryGetValue(answer, out count) ? count + 1 : 1;
        }

        int result = dict.Select(x => (x.Key + x.Value - 1) / x.Key * x.Key).Sum();
        Console.WriteLine(result);
    }
}