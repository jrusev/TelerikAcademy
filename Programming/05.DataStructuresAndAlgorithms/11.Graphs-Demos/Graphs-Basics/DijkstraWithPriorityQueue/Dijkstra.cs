namespace DijkstraWithPriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class Dijkstra
    {
        public static void Main()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);
            Node node7 = new Node(7);
            Node node8 = new Node(8);
            Node node9 = new Node(9);
            Node node10 = new Node(10);

            List<Node> nodes = new List<Node>();

            nodes.Add(node1);
            nodes.Add(node2);
            nodes.Add(node3);
            nodes.Add(node4);
            nodes.Add(node5);
            nodes.Add(node6);
            nodes.Add(node7);
            nodes.Add(node8);
            nodes.Add(node9);
            nodes.Add(node10);

            var graph = new Dictionary<Node, List<Edge>>()
            {
                { node1, new List<Edge> { new Edge(node2, 23), new Edge(node8, 8) } },
                { node2, new List<Edge> { new Edge(node1, 23), new Edge(node4, 3), new Edge(node7, 34) } },
                { node3, new List<Edge> { new Edge(node4, 6), new Edge(node8, 25), new Edge(node10, 7) } },
                { node4, new List<Edge> { new Edge(node2, 3), new Edge(node3, 6) } },
                { node5, new List<Edge> { new Edge(node6, 10) } },
                { node6, new List<Edge> { new Edge(node5, 10) } },
                { node7, new List<Edge> { new Edge(node2, 34) } },
                { node8, new List<Edge> { new Edge(node1, 8), new Edge(node3, 25), new Edge(node10, 30) } },
                { node9, new List<Edge> { } },
                { node10, new List<Edge> { new Edge(node3, 7), new Edge(node8, 30) } },
            };

            Node source = node1;

            DijkstraAlgorithm(graph, source);

            for (int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine("Distance from {0} to {1} is {2}", source.ID, i + 1, nodes[i].MinDistance);
            }
        }

        public static void DijkstraAlgorithm(Dictionary<Node, List<Edge>> graph, Node source)
        {
            var pQueue = new PriorityQueue<Node>();
            source.MinDistance = 0.0;
            pQueue.Enqueue(source);

            while (pQueue.Count != 0)
            {
                Console.WriteLine(string.Join<Node>(", ", pQueue.heap));
                Node currentNode = pQueue.Dequeue();

                foreach (var neighbour in graph[currentNode])
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
}
