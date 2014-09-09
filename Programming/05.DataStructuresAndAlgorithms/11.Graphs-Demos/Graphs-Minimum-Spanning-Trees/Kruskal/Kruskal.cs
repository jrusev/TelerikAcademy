using System;
using System.Collections.Generic;
using System.Linq;

class Kruskal
{
    static void Main()
    {
        var edges = BuildGraph();

        var set = new HashSet<int>();
        foreach (var edge in edges)
        {
            set.Add(edge.StartNode);
            set.Add(edge.EndNode);
        }

        int numNodes = set.Count;

        edges.Sort();

        int[] tree = new int[numNodes + 1]; //we start from 1, not from 0
        List<Edge> mpd = new List<Edge>();
        int treesCount = 1;

        treesCount = FindMinimumSpanningTree(edges, tree, mpd, treesCount);

        Console.WriteLine("Edges in the MST: {0}", string.Join(" ", mpd));
        Console.WriteLine("Sum of the weights: {0}", mpd.Sum(e => e.Weight));
    }

    private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
    {
        foreach (var edge in edges)
        {
            if (tree[edge.StartNode] == 0) // not visited
            {
                if (tree[edge.EndNode] == 0) // both ends are not visited
                {
                    tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                    treesCount++;
                }
                else
                {
                    // attach the start node to the tree of the end node
                    tree[edge.StartNode] = tree[edge.EndNode];
                }
                mpd.Add(edge);
            }
            else // the start is part of a tree
            {
                if (tree[edge.EndNode] == 0)
                {
                    //attach the end node to the tree;
                    tree[edge.EndNode] = tree[edge.StartNode];
                    mpd.Add(edge);
                }
                else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                {
                    int oldTreeNumber = tree[edge.EndNode];

                    for (int i = 0; i < tree.Length; i++)
                    {
                        if (tree[i] == oldTreeNumber)
                        {
                            tree[i] = tree[edge.StartNode];
                        }
                    }
                    mpd.Add(edge);
                }
            }
        }
        return treesCount;
    }

    private static List<Edge> BuildGraph()
    {
        var edges = new List<Edge>();

        edges.Add(new Edge(1, 2, 1));
        edges.Add(new Edge(1, 4, 2));
        edges.Add(new Edge(2, 3, 3));
        edges.Add(new Edge(2, 5, 13));
        edges.Add(new Edge(3, 4, 4));
        edges.Add(new Edge(3, 6, 3));
        edges.Add(new Edge(4, 6, 16));
        edges.Add(new Edge(4, 7, 14));
        edges.Add(new Edge(5, 6, 12));
        edges.Add(new Edge(5, 8, 1));
        edges.Add(new Edge(5, 9, 13));
        edges.Add(new Edge(6, 7, 1));
        edges.Add(new Edge(6, 9, 1));

        return edges;
    }
}