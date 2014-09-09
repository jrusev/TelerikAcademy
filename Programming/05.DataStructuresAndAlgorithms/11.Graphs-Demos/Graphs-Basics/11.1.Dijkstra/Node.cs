using System;
using System.Collections.Generic;

public class Node : IComparable<Node>
{
    public Node(string name)
    {
        this.Id = name;
        this.MinDistance = int.MaxValue;
        this.Neighbors = new List<Edge>();
    }

    public IList<Edge> Neighbors { get; set; }

    public double MinDistance { get; set; }

    public int CompareTo(Node other)
    {
        return this.MinDistance.CompareTo(other.MinDistance);
    }

    public string Id { get; set; }
}

