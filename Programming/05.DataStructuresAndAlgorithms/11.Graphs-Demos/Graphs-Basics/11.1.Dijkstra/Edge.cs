public class Edge
{
    public Edge(Node node, int distance)
    {
        this.Node = node;
        this.Distance = distance;
    }

    public Node Node { get; set; }

    public int Distance { get; private set; }
}

