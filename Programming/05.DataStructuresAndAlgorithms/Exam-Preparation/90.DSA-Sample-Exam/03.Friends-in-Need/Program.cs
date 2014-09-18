using System;
using System.Collections.Generic;
using System.Linq;

class FriendsOfPesho
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int numNodes = tokens[0];
        int numEdges = tokens[1];

        var graph = Enumerable.Range(0, numNodes).Select(i => new List<Neighbor>()).ToArray();
        var hospitals = new HashSet<int>(Console.ReadLine().Split(' ').Select(a => int.Parse(a) - 1));

        for (int i = 0; i < numEdges; i++)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int node1 = input[0] - 1;
            int node2 = input[1] - 1;
            int dist = input[2];

            graph[node1].Add(new Neighbor() { Id = node2, DistTo = dist });
            graph[node2].Add(new Neighbor() { Id = node1, DistTo = dist });
        }

        var minDist = Int32.MaxValue;
        foreach (var id in hospitals)
            minDist = Math.Min(minDist, Dijkstra(graph, id).Where((dist, i) => !hospitals.Contains(i)).Sum());

        Console.WriteLine(minDist);
    }

    static int[] Dijkstra(IList<Neighbor>[] graph, int source)
    {
        var queue = new Queue<int>();
        queue.Enqueue(source);

        var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
        distances[source] = 0;

        while (queue.Count != 0)
        {
            int currentNodeId = queue.Dequeue();
            foreach (var neighbour in graph[currentNodeId])
            {
                int newDistance = distances[currentNodeId] + neighbour.DistTo;
                if (newDistance < distances[neighbour.Id])
                {
                    distances[neighbour.Id] = newDistance;
                    queue.Enqueue(neighbour.Id);
                }
            }
        }

        return distances;
    }

    struct Neighbor { public int Id, DistTo; }
}