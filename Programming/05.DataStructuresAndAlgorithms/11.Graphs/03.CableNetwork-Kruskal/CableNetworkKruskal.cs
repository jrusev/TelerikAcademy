using System;
using System.Linq;

// You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house).
// If it is constrained to bury the cable only along certain paths,
// then there would be a graph representing which points are connected by those paths.
// But the cost of some of the paths is more expensive because they are longer.
// If every house is a node and every path from house to house is an edge, find a way to minimize the cost for cables.
class CableNetworkKruskal
{
    const int NoParent = -1;
    static int[] pred;

    static void Main()
    {
        var edges = BuildGraph();
        int vertexCount = edges.Max(e => Math.Max(e.Node1, e.Node2));
        pred = Enumerable.Repeat(NoParent, vertexCount + 1).ToArray();
        FindMinSpanTree(edges);
    }

    // Kruskal's algorithm
    // For a graph with vertices V and edges E, complexity is O(E log V)
    static void FindMinSpanTree(Edge[] edges)
    {
        Array.Sort(edges); // Sort the edges by weight

        Console.WriteLine("Edges in the minimum spanning tree (using Kruskal):");
        int totalCost = 0;
        for (int i = 0; i < edges.Length; i++)
        {
            int rootNode1 = FindRoot(edges[i].Node1);
            int rootNode2 = FindRoot(edges[i].Node2);
            // Check if Node1 and Node2 are not in the same tree (in the MST, not in the graph) to avoid loops
            if (rootNode1 != rootNode2)
            {
                Console.Write("({0}, {1}) ", edges[i].Node1, edges[i].Node2);
                totalCost += edges[i].Cost;
                pred[rootNode2] = rootNode1; // Combine the two subtrees
            }
        }

        Console.WriteLine("\nThe cost of the minimum spanning tree is {0}.", totalCost);
    }

    static int FindRoot(int vertex)
    {
        // Find the root of the tree starting from the vertex
        int root = vertex;
        while (pred[root] != NoParent) root = pred[root];

        // Path compression:
        // This step is not necessary, but it will reduce the root search time.
        // All nodes in the path from 'vertex' to 'root' will become children of 'root'
        int temp = 0;
        while (vertex != root)
        {
            temp = vertex;
            vertex = pred[vertex];
            pred[temp] = root;
        }
        return root;
    }

    static Edge[] BuildGraph()
    {
        return new[]
        {
            new Edge() { Node1 = 1, Node2 = 2, Cost = 1  },
            new Edge() { Node1 = 1, Node2 = 4, Cost = 2  },
            new Edge() { Node1 = 2, Node2 = 3, Cost = 3  },
            new Edge() { Node1 = 2, Node2 = 5, Cost = 13 },
            new Edge() { Node1 = 3, Node2 = 4, Cost = 4  },
            new Edge() { Node1 = 3, Node2 = 6, Cost = 3  },
            new Edge() { Node1 = 4, Node2 = 6, Cost = 16 },
            new Edge() { Node1 = 4, Node2 = 7, Cost = 14 },
            new Edge() { Node1 = 5, Node2 = 6, Cost = 12 },
            new Edge() { Node1 = 5, Node2 = 8, Cost = 1  },
            new Edge() { Node1 = 5, Node2 = 9, Cost = 13 },
            new Edge() { Node1 = 6, Node2 = 7, Cost = 1  },
            new Edge() { Node1 = 6, Node2 = 9, Cost = 1  }
        };
    }
}

struct Edge : IComparable<Edge>
{
    public int Node1 { get; set; }
    public int Node2 { get; set; }
    public int Cost { get; set; }

    public int CompareTo(Edge other)
    {
        return this.Cost.CompareTo(other.Cost);
    }
}