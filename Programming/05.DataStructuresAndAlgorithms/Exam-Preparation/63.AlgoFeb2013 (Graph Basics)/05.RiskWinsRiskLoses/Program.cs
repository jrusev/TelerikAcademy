using System;
using System.Collections.Generic;
using System.Linq;

// http://bgcoder.com/Contests/Practice/Index/63#4
class Program
{
    static int target;
    static int[] minTurns;
    static readonly int[] powerOf10 = new[] { 1, 10, 100, 1000, 10000, 100000 };

    static void Main()
    {
        int initial = int.Parse(Console.ReadLine());
        target = int.Parse(Console.ReadLine());
        int forbiddenCount = int.Parse(Console.ReadLine());

        minTurns = Enumerable.Repeat(int.MaxValue, 100000).ToArray();
        for (int i = 0; i < forbiddenCount; i++)
        {
            int forbidden = int.Parse(Console.ReadLine());
            minTurns[forbidden] = -1;
        }

        minTurns[initial] = 0;

        var queue = new Queue<int>();
        queue.Enqueue(initial);
        while (queue.Count != 0)
        {
            var node = queue.Dequeue();
            if (node == target)           
                break;           

            for (int p = 0; p < 5; p++)
            {
                MakeNewNode(queue, node, p, true);
                MakeNewNode(queue, node, p, false);
            }
        }


        Console.WriteLine(minTurns[target] == int.MaxValue ? -1 : minTurns[target]);
    }

    private static void MakeNewNode(Queue<int> queue, int node, int p, bool increase)
    {
        int newNode = node;
        int digit = (node / powerOf10[p]) % 10;

        if (increase)
        {
            if (digit == 9) newNode -= 9 * powerOf10[p];
            else newNode += powerOf10[p];
        }
        else
        {
            if (digit == 0) newNode += 9 * powerOf10[p];
            else newNode -= powerOf10[p];
        }

        if (minTurns[newNode] == int.MaxValue)
        {
            minTurns[newNode] = minTurns[node] + 1;
            queue.Enqueue(newNode);
        }
    }
}
