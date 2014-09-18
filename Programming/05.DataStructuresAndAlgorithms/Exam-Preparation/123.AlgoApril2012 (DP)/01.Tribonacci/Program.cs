using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        long t1 = input[0];
        long t2 = input[1];
        long t3 = input[2];
        int n = input[3];

        if (n < 3)
        {
            Console.WriteLine(input[n]);
            return;
        }

        for (int i = 3; i < n; i++)
        {
            long temp = t1 + t2 + t3;
            t1 = t2;
            t2 = t3;
            t3 = temp;
        }

        Console.WriteLine(t3);
    }
}
