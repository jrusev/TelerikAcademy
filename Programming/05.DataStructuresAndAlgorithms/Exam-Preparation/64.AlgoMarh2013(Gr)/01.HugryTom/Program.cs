using System;
using System.Collections.Generic;
using System.Linq;

// http://bgcoder.com/Contests/Practice/Index/64#1
class Program
{
    const int StartNode = 1;

    static readonly List<int[]> allPaths = new List<int[]>();
    static readonly ISet<int> currentPath = new HashSet<int>();

    static IDictionary<int, ISet<int>> nodes;
    static bool[] visited;

    static void Main()
    {
        int numNodes = int.Parse(Console.ReadLine());
        int numEdges = int.Parse(Console.ReadLine());

        nodes = new Dictionary<int, ISet<int>>(numNodes);
        visited = new bool[numNodes + 1];

        for (int i = 0; i < numEdges; i++)
        {
            var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int node1 = edge[0], node2 = edge[1];

            GetOrCreateNode(node1, node2);
            GetOrCreateNode(node2, node1);
        }

        visited[StartNode] = true;

        FindAllHamiltonianCycles(StartNode);

        PrintResult();
    }

    static void FindAllHamiltonianCycles(int root, int currentLevel = 1)
    {
        if (!nodes.ContainsKey(root)) return;

        if (nodes.Count == currentLevel && nodes[root].Contains(StartNode))
        {
            allPaths.Add(currentPath.ToArray());
            return;
        }

        foreach (var neighbour in nodes[root])
        {
            if (!visited[neighbour])
            {
                visited[neighbour] = true;
                currentPath.Add(neighbour);

                FindAllHamiltonianCycles(neighbour, currentLevel + 1);

                currentPath.Remove(neighbour);
                visited[neighbour] = false;
            }
        }
    }

    static void PrintResult()
    {
        if (allPaths.Count == 0)
        {
            Console.WriteLine(-1);
            return;
        }

        Console.WriteLine(allPaths.Count);

        allPaths.Sort((arr1, arr2) =>
        {
            int result = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                result = arr1[i].CompareTo(arr2[i]);

                if (result != 0) return result;
            }

            return result;
        });

        foreach (var path in allPaths)
            Console.WriteLine("{0} {1} {0}", StartNode, string.Join(" ", path));
    }

    static void GetOrCreateNode(int node1, int node2)
    {
        if (!nodes.ContainsKey(node1))
            nodes[node1] = new HashSet<int>();

        nodes[node1].Add(node2);
    }
}