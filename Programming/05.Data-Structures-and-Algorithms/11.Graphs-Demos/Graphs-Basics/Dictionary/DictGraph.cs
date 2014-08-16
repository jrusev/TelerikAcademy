using System;
using System.Collections.Generic;

public class DictGraph
{
    public static void Main()
    {
        var graph = new Dictionary<string, List<string>>();

        string input;
        while ((input = Console.ReadLine()) != string.Empty)
        {
            string[] nodes = input.Split(' ');
            ConnectNodes(graph, nodes[0], nodes[1]);
            ConnectNodes(graph, nodes[1], nodes[0]);
        }

        PrintGraph(graph);
    }

    private static void ConnectNodes(Dictionary<string, List<string>> graph, string first, string second)
    {
        if (!graph.ContainsKey(first))
        {
            graph[first] = new List<string>();
        }

        graph[first].Add(second);
    }

    private static void PrintGraph(Dictionary<string, List<string>> graph)
    {
        foreach (var node in graph)
        {
            Console.Write(node.Key + " -> ");
            Console.WriteLine(string.Join(" ", node.Value));
        }
    }
}
