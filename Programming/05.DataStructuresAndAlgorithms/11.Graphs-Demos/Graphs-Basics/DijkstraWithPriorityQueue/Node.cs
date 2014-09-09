namespace DijkstraWithPriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.ID = id;
            this.MinDistance = double.PositiveInfinity;
        }

        public int ID { get; private set; }

        public double MinDistance { get; set; }

        public int CompareTo(object obj)
        {
            return this.MinDistance.CompareTo((obj as Node).MinDistance);
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.ID.ToString();
        }
    }
}
