using System;

// You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house).
// If it is constrained to bury the cable only along certain paths,
// then there would be a graph representing which points are connected by those paths.
// But the cost of some of the paths is more expensive because they are longer.
// If every house is a node and every path from house to house is an edge, find a way to minimize the cost for cables.
class CableNetworkPrim
{
    static void Main()
    {
        var adjMatrix = BuildGraph();
        FindMinSpanningTree(adjMatrix);
    }

    // Prim's algorithm
    // For a graph with vertices V, complexity is O(V^2)
    static void FindMinSpanningTree(int[,] adjMatrix)
    {
        Console.WriteLine("Edges in the minimum spanning tree (using Prim):");

        int n = adjMatrix.GetLength(0);
        var used = new bool[n];
        var previous = new int[n];
        var minCostCache = new int[n];

        used[0] = true; // Select initial vertex at random
        for (int i = 0; i < n; i++)
            minCostCache[i] = (adjMatrix[0, i] != 0) ? adjMatrix[0, i] : int.MaxValue;

        int totalCost = 0;
        for (int k = 0; k < n - 1; k++)
        {
            // Search next edge with minimum weight
            int minCost = int.MaxValue;
            int j = -1;
            for (int i = 0; i < n; i++)
            {
                if (!used[i] && minCostCache[i] < minCost)
                {
                    minCost = minCostCache[i];
                    j = i;
                }
            }

            used[j] = true;
            Console.Write("({0}, {1}) ", previous[j] + 1, j + 1);
            totalCost += minCost;

            // Update the min cost edge for the current vertex
            for (int i = 0; i < n; i++)
            {
                if (!used[i] && adjMatrix[j, i] != 0 && minCostCache[i] > adjMatrix[j, i])
                {
                    minCostCache[i] = adjMatrix[j, i];
                    // Store the predecessor
                    previous[i] = j;
                }
            }
        }

        Console.WriteLine("\nThe cost of the minimum spanning tree is {0}.", totalCost);
    }

    static int[,] BuildGraph()
    {
        return new int[,]
        {
            { 0,  1, 0,  2,  0,  0,  0, 0,  0 },
            { 1,  0, 3,  0, 13,  0,  0, 0,  0 },
            { 0,  3, 0,  4,  0,  3,  0, 0,  0 },
            { 2,  0, 4,  0,  0, 16, 14, 0,  0 },
            { 0, 13, 0,  0,  0, 12,  0, 1, 13 },
            { 0,  0, 3, 16, 12,  0,  1, 0,  1 },
            { 0,  0, 0, 14,  0,  1,  0, 0,  0 },
            { 0,  0, 0,  0,  1,  0,  0, 0,  0 },
            { 0,  0, 0,  0, 13,  1,  0, 0,  0 }
        };
    }
}
