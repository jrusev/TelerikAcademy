using System;
using System.Collections;
using System.Collections.Generic;

public class Graph : IEnumerable<Node>
{
    public IDictionary<string, Node> Nodes { get; private set; }

    public Graph()
    {
        this.Nodes = new Dictionary<string, Node>();
    }

    public void AddNode(string name)
    {
        this.Nodes.Add(name, new Node(name));
    }

    public void AddEdge(string from, string to, int dist, bool directed = false)
    {
        Node fromNode;
        if (!Nodes.TryGetValue(from, out fromNode))
        {
            fromNode = new Node(from);
            Nodes.Add(from, fromNode);
        }

        Node toNode;
        if (!Nodes.TryGetValue(to, out toNode))
        {
            toNode = new Node(to);
            Nodes.Add(to, toNode);
        }

        fromNode.Edges.Add(new Edge(toNode, dist));

        if (!directed)
        {
            toNode.Edges.Add(new Edge(fromNode, dist));
        }
    }

    public Node this[string key]
    {
        get
        {
            return this.Nodes[key];
        }
        set
        {
            this.Nodes[key] = value;
        }
    }

    public IEnumerator<Node> GetEnumerator()
    {
        foreach (var kvp in this.Nodes)
        {
            yield return kvp.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public class Node : IComparable<Node>
{
    public Node(string name)
    {
        this.Name = name;
        this.MinDistance = int.MaxValue;
        this.Edges = new List<Edge>();
    }

    public IList<Edge> Edges { get; set; }

    public int MinDistance { get; set; }

    public int CompareTo(Node other)
    {
        return this.MinDistance.CompareTo(other.MinDistance);
    }

    public string Name { get; set; }

    public override string ToString()
    {
        return string.Format("{0}({1})", this.Name, this.MinDistance);
    }
}

public class Edge
{
    public Edge(Node neighbor, int distance)
    {
        this.Neighbor = neighbor;
        this.Distance = distance;
    }

    public Node Neighbor { get; set; }

    public int Distance { get; private set; }
}