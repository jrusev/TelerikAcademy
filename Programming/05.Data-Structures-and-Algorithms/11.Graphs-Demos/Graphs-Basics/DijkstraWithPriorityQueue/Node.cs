namespace DijkstraWithPriorityQueue
{
    using System;

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.ID = id;
        }

        public int ID { get; private set; }

        public double DijkstraDistance { get; set; }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }
}
