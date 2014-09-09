using System;
using System.Linq;

public class AdjMatrix
{
    public static void Main()
    {
        int numNodes = int.Parse(Console.ReadLine());

        var graph = new int[numNodes, numNodes];

        for (int i = 0; i < numNodes; i++)
        {
            var neighbors = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s));

            foreach (var neighbor in neighbors)
            {
                graph[i, neighbor] = 1;
            }
        }

        PrintGraph(graph);
    }

    private static void PrintGraph(int[,] graph)
    {
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                Console.Write(graph[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}
