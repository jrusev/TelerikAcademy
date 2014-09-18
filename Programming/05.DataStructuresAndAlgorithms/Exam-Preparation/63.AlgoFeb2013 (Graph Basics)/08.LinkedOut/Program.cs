using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LinkedOut
{
    private static readonly IDictionary<string, Node> nodes = new Dictionary<string, Node>();

    internal static void Main()
    {
        var root = GetOrCreateNode(Console.ReadLine());
        BuildGraph();
        CalcDegreesOfSeparationBFS(root);
        PrintResult();
    }

    private static void BuildGraph()
    {
        var numberOfConnections = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfConnections; i++)
        {
            var edge = Console.ReadLine().Split(' ').ToArray();
            var node1 = GetOrCreateNode(edge[0]);
            var node2 = GetOrCreateNode(edge[1]);

            node1.Neighbors.Add(node2);
            node2.Neighbors.Add(node1);
        }
    }

    private static void CalcDegreesOfSeparationBFS(Node root)
    {
        var visited = new HashSet<string>();
        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            visited.Add(node.Name);

            foreach (var child in node.Neighbors)
            {
                if (!visited.Contains(child.Name))
                {
                    child.DegreesOfSeparation = node.DegreesOfSeparation + 1;
                    visited.Add(child.Name);
                    queue.Enqueue(child);
                }
            }
        }
    }

    private static void PrintResult()
    {
        var output = new StringBuilder();

        var numOfConnections = int.Parse(Console.ReadLine());
        for (int i = 0; i < numOfConnections; i++)
        {
            var name = Console.ReadLine();
            var node = GetOrCreateNode(name);
            if (node.DegreesOfSeparation == 0)
            {
                output.AppendLine("-1");
            }
            else
            {
                output.AppendLine(node.DegreesOfSeparation.ToString());
            }
        }

        Console.WriteLine(output.ToString());
    }

    private static Node GetOrCreateNode(string name)
    {
        Node node;
        nodes.TryGetValue(name, out node);

        if (node == null)
        {
            node = new Node(name);
            nodes[name] = node;
        }

        return node;
    }
}

public class Node
{
    public Node(string name)
    {
        this.Name = name;
        this.Neighbors = new HashSet<Node>();
    }

    public string Name { get; set; }

    public int DegreesOfSeparation { get; set; }

    public ICollection<Node> Neighbors { get; set; }
}