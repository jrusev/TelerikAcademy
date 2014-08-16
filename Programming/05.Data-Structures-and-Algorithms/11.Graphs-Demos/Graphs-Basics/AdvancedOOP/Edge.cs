namespace GraphOOP
{
    internal class Edge
    {
        internal Edge(Node target, double distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        internal Node Target { get; private set; }

        internal double Distance { get; private set; }

        public override string ToString()
        {
            return this.Target + "-" + this.Distance;
        }
    }
}
