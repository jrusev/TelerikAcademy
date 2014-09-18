using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Sorting
{

    const string Test001 = @"3
1 2 3
3
";

    const string Test002 = @"3
3 2 1
3
";

    const string Test003 = @"5
5 4 3 2 1
2
";

    const string Test004 = @"5
3 2 4 1 5
4
";

    const string Test005 = @"8
7 2 1 6 8 4 3 5
4
";

    static HashSet<string> used = new HashSet<string>();

    static HashSet<int> usedInts = new HashSet<int>();

    public static void Main()
    {
        Console.SetIn(new StringReader(Test003));

        int N = int.Parse(Console.ReadLine());
        var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int K = int.Parse(Console.ReadLine());

        var sortedArr = nums.OrderBy(x => x).ToArray();

        var queue = new Queue<Tuple<int[], int>>();
        queue.Enqueue(Tuple.Create(nums, 0));
        used.Add(string.Join("", nums));

        usedInts.Add(GetHash(nums));


        while (queue.Count != 0)
        {
            var node = queue.Dequeue();
            if (node.Item1.SequenceEqual(sortedArr))
            {
                Console.WriteLine(node.Item2);
                return;
            }

            for (int i = 0; i <= N - K; i++)
            {
                var perm = Reverse(i, i + K - 1, node.Item1);
                //var hash = string.Join("", perm);

                //if (!used.Contains(hash))
                //{
                //    //Console.WriteLine(hash);
                //    //Console.ReadKey(true);
                //    queue.Enqueue(Tuple.Create(perm, node.Item2 + 1));
                //    used.Add(hash);
                //}

                if (!usedInts.Contains(GetHash(perm)))
                {
                    //Console.WriteLine(hash);
                    //Console.ReadKey(true);
                    queue.Enqueue(Tuple.Create(perm, node.Item2 + 1));
                    usedInts.Add(GetHash(perm));
                }
            }
        }

        Console.WriteLine(-1);
    }

    private static int[] Reverse(int i, int j, int[] source)
    {
        if (i > j)
        {
            throw new ArgumentOutOfRangeException("Start index must be less than the end index!");
        }

        int[] target = new int[source.Length];
        Array.Copy(source, target, source.Length);

        while (i < j)
        {
            int temp = target[i];
            target[i] = target[j];
            target[j] = temp;
            i += 1;
            j -= 1;
        }

        return target;
    }

    private static int GetHash(int[] arr)
    {
        int hash = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            hash = hash * 10 + arr[i];
        }
        return hash;
    }
}
