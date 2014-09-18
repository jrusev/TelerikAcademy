using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
    static HashSet<int> visited = new HashSet<int>();

    static void Main()
    {
        foreach (int i in Enumerable.Range(0, int.Parse(Console.ReadLine()) - 1))
        {
            var edge = Regex.Matches(Console.ReadLine(), @"\d+");

            var node1 = int.Parse(edge[0].Value);
            var node2 = int.Parse(edge[1].Value);

            if (!adjacencyList.ContainsKey(node1))
                adjacencyList[node1] = new List<int>();

            adjacencyList[node1].Add(node2);

            if (!adjacencyList.ContainsKey(node2))
                adjacencyList[node2] = new List<int>();

            adjacencyList[node2].Add(node1);
        }

        long maxSum = long.MinValue;
        foreach (int leaf in FindLeaves())
        {
            maxSum = Math.Max(FindMaxSum(leaf), maxSum);
            visited.Clear();
        }

        Console.WriteLine(maxSum);
    }

    static long FindMaxSum(int node)
    {
        visited.Add(node);

        long sum = 0;

        foreach (int neighbor in adjacencyList[node])
        {
            if (!visited.Contains(neighbor))
            {
                sum = Math.Max(sum, FindMaxSum(neighbor));
            }
        }

        return node + sum;
    }

    static IEnumerable<int> FindLeaves()
    {
        return adjacencyList.Where(kvp => kvp.Value.Count == 1).Select(kvp => kvp.Key);
    }
}