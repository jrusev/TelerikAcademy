using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianCycle
{
    class Program
    {
        static List<List<Node>> cycles = new List<List<Node>>();
        static Node startNode = new Node('A');
        static Node b = new Node('B');
        static Node c = new Node('C');
        static Node d = new Node('D');
        static Node e = new Node('E');
        static Node f = new Node('F');

        static void Main(string[] args)
        {
            GenerateGraph();
            startNode.Visited = true;
            List<Node> path = new List<Node>();
            path.Add(startNode);
            int nodesCount = 6;
            HamiltonianCycle(startNode, 1, path, nodesCount);

            foreach (List<Node> list in cycles)
            {
                foreach (Node item in list)
                {
                    Console.Write(item.Letter + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("There are {0} Hamiltonian cycles", cycles.Count);
        }

        public static void HamiltonianCycle(Node node, int level, List<Node> pathSoFar, int nodesCount)
        {
            if (level == nodesCount)
            {
                foreach (Node neighbor in node.Neighbors)
                {
                    if (neighbor == startNode)
                    {
                        List<Node> p = new List<Node>();
                        p.AddRange(pathSoFar);
                        cycles.Add(p);
                        break;
                    }
                }
                return;
            }
            for (int i = 0; i < node.Neighbors.Count; i++)
            {
                if (!node.Neighbors[i].Visited)
                {
                    node.Neighbors[i].Visited = true;
                    pathSoFar.Add(node.Neighbors[i]);
                    HamiltonianCycle(node.Neighbors[i], level + 1, pathSoFar, nodesCount);
                    pathSoFar.Remove(node.Neighbors[i]);

                    node.Neighbors[i].Visited = false;

                }
            }

        }

        private static void GenerateGraph()
        {
            startNode.Neighbors.Add(b);
            startNode.Neighbors.Add(c);
            startNode.Neighbors.Add(d);
            startNode.Neighbors.Add(f);

            b.Neighbors.Add(startNode);
            b.Neighbors.Add(c);
            b.Neighbors.Add(d);
            b.Neighbors.Add(e);

            c.Neighbors.Add(startNode);
            c.Neighbors.Add(b);
            c.Neighbors.Add(e);
            c.Neighbors.Add(f);

            d.Neighbors.Add(startNode);
            d.Neighbors.Add(b);
            d.Neighbors.Add(e);
            d.Neighbors.Add(f);

            e.Neighbors.Add(b);
            e.Neighbors.Add(c);
            e.Neighbors.Add(d);
            e.Neighbors.Add(f);

            f.Neighbors.Add(startNode);
            f.Neighbors.Add(c);
            f.Neighbors.Add(d);
            f.Neighbors.Add(e);

        }
    }
}
