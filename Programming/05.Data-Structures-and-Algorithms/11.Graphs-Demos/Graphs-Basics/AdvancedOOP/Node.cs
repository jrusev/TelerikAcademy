namespace GraphOOP
{
    using System;
    using System.Collections.Generic;

    internal class Node
    {
        internal Node(string name)
        {
            this.Name = name;
            this.Connections = new List<Edge>();
        }

        internal string Name { get; private set; }

        internal IList<Edge> Connections { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }

        internal void AddConnection(Node targetNode, double distance, bool directed)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance <= 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            this.Connections.Add(new Edge(targetNode, distance));

            if (!directed)
            {
                targetNode.AddConnection(this, distance, true);
            }
        }
    }
}