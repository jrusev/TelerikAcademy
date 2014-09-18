using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem
{
    class Program
    {
        static Node a = new Node('A');
        static Node b = new Node('B');
        static Node c = new Node('C');
        static Node d = new Node('D');
        static int nodesNumber = 4;

        static int minPathLength = int.MaxValue;
        static List<KeyValuePair<Node, int>> minPath = new List<KeyValuePair<Node,int>>();

        static List<List<KeyValuePair<Node, int>>> cycles = new List<List<KeyValuePair<Node, int>>>();

        public static void HamiltonianCycle(Node node, int level, List<KeyValuePair<Node, int>> pathSoFar)
        {
            if (level == nodesNumber)
            {
                foreach (KeyValuePair<Node, int> item in node.Neighbors)
                {
                    if (item.Key == a)
                    {
                        List<KeyValuePair<Node, int>> p = new List<KeyValuePair<Node, int>>();
                        p.AddRange(pathSoFar);
                        p.Add(new KeyValuePair<Node, int>(a, item.Value));
                        cycles.Add(p);
                        break;
                    }
                }
                return;
            }
            for (int i = 0; i < node.Neighbors.Count; i++)
            {
                if (!node.Neighbors[i].Key.Visited)
                {
                    node.Neighbors[i].Key.Visited = true;
                    KeyValuePair<Node, int> currentNode =
                        new KeyValuePair<Node, int>(node.Neighbors[i].Key, node.Neighbors[i].Value);
                    pathSoFar.Add(currentNode);
                    HamiltonianCycle(node.Neighbors[i].Key, level + 1, pathSoFar);
                    pathSoFar.Remove(currentNode);
                    node.Neighbors[i].Key.Visited = false;

                }
            }

        }

        private static void GenerateGraph()
        {
            a.Neighbors.Add(new KeyValuePair<Node, int>(b, 30));
            a.Neighbors.Add(new KeyValuePair<Node, int>(c, 40));
            a.Neighbors.Add(new KeyValuePair<Node, int>(d, 70));

            b.Neighbors.Add(new KeyValuePair<Node, int>(a, 30));
            b.Neighbors.Add(new KeyValuePair<Node, int>(c, 60));
            b.Neighbors.Add(new KeyValuePair<Node, int>(d, 40));

            c.Neighbors.Add(new KeyValuePair<Node, int>(a, 40));
            c.Neighbors.Add(new KeyValuePair<Node, int>(b, 60));
            c.Neighbors.Add(new KeyValuePair<Node, int>(d, 50));

            d.Neighbors.Add(new KeyValuePair<Node, int>(a, 70));
            d.Neighbors.Add(new KeyValuePair<Node, int>(b, 40));
            d.Neighbors.Add(new KeyValuePair<Node, int>(c, 50));
        }

        public static int CalculatePathLength(List<KeyValuePair<Node, int>> path)
        {
            int pathLength = 0;
            foreach (KeyValuePair<Node, int> pair in path)
            {
                pathLength = pathLength + pair.Value;
            }
            return pathLength;
        }

        static void Main(string[] args)
        {
            GenerateGraph();
            a.Visited = true;
            List<KeyValuePair<Node, int>> path = new List<KeyValuePair<Node,int>>();
            path.Add(new KeyValuePair<Node, int>(a, 0));
            HamiltonianCycle(a, 1, path);
            foreach (List<KeyValuePair<Node, int>> list in cycles)
            {
                foreach (KeyValuePair<Node, int> item in list)
                {
                    Console.Write(item.Key.Letter + " ");
                }
                int pathLength = CalculatePathLength(list);
                Console.WriteLine("with path -> {0}", pathLength);
                if (pathLength < minPathLength)
                {
                    minPathLength = pathLength;
                    minPath.Clear();
                    minPath.AddRange(list);
                }
            }

            Console.WriteLine();
            Console.Write("The shortest path is: ");
            foreach (KeyValuePair<Node, int> pair in minPath)
            {
                Console.Write(pair.Key.Letter + " ");
            }
            Console.WriteLine("with length {0}", minPathLength);
            Console.WriteLine();
        }
    }
}
