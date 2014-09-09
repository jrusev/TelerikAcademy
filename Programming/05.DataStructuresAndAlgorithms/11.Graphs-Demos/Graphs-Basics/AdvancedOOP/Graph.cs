namespace GraphOOP
{
    using System.Collections.Generic;
    using System.Text;

    public class Graph
    {
        public Graph()
        {
            this.Nodes = new Dictionary<string, Node>();
        }

        internal IDictionary<string, Node> Nodes { get; private set; }

        public void AddNode(string name)
        {
            this.Nodes.Add(name, new Node(name));
        }

        public void AddEdge(string from, string to, int distance, bool directed = false)
        {
            var fromNode = this.RegisterNode(from);
            var toNode = this.RegisterNode(to);

            fromNode.AddConnection(toNode, distance, directed);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.AppendLine(node.Key + " -> " + string.Join(" ", node.Value.Connections));
            }

            return result.ToString();
        }

        private Node RegisterNode(string nodeName)
        {
            if (!this.Nodes.ContainsKey(nodeName))
            {
                this.Nodes[nodeName] = new Node(nodeName);
            }

            return this.Nodes[nodeName];
        }
    }
}
