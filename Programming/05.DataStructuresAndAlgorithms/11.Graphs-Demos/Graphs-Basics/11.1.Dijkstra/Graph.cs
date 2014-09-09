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

        fromNode.Neighbors.Add(new Edge(toNode, dist));

        if (!directed)
        {
            toNode.Neighbors.Add(new Edge(fromNode, dist));
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