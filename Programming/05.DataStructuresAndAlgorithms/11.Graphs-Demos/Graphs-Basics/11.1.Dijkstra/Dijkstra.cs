using System;
using System.Linq;

public class Dijkstra
{
    public static void Main()
    {
        var g = new Graph();
        g.AddEdge("1", "2", 23); g.AddEdge("1", "8", 8); g.AddEdge("2", "4", 3);
        g.AddEdge("2", "7", 34); g.AddEdge("3", "4", 6); g.AddEdge("3", "8", 25);
        g.AddEdge("3", "10", 7); g.AddEdge("5", "6", 10); g.AddEdge("8", "10", 30);
        g.AddNode("9");

        Node source = g["2"];
        DijkstraAlgorithm(g, source);

        foreach (var name in g.Nodes.Keys.OrderBy(s => int.Parse(s)))
        {
            Node target = g[name];
            Console.WriteLine("Distance from {0} to {1} is {2}", source.Id, target.Id, target.MinDistance);
        }
    }

    public static void DijkstraAlgorithm(Graph graph, Node source)
    {
        foreach (var node in graph)
        {
            node.MinDistance = double.PositiveInfinity;
        }

        source.MinDistance = 0;

        var pQueue = new PriorityQueue<Node>();
        pQueue.Enqueue(source);

        while (pQueue.Count != 0)
        {
            Node currentNode = pQueue.Dequeue();

            foreach (var neighbour in graph[currentNode.Id].Neighbors)
            {
                double newDist = currentNode.MinDistance + neighbour.Distance;

                if (newDist < neighbour.Node.MinDistance)
                {
                    neighbour.Node.MinDistance = newDist;
                    pQueue.Enqueue(neighbour.Node);
                }
            }
        }
    }
}

