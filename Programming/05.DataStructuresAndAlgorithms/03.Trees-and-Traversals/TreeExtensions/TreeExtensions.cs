namespace TreeExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TreeExtensions
    {
        public static int NumberOfNodes(this Node<int> node)
        {
            int numberOfNodes = 1;
            foreach (var child in node.Children)
            {
                numberOfNodes += NumberOfNodes(child);
            }

            return numberOfNodes;
        }

        public static int NumberOfNodesStack(this Node<int> root)
        {
            var stack = new Stack<Node<int>>();
            stack.Push(root);
            int numberOfNodes = 0;

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                numberOfNodes++;
                foreach (var child in node.Children)
                {
                    stack.Push(child);
                }
            }

            return numberOfNodes;
        }

        public static int Height(this Node<int> node)
        {
            int maxHeight = 0;
            foreach (var child in node.Children)
            {
                maxHeight = Math.Max(maxHeight, Height(child));
            }

            return 1 + maxHeight;
        }

        public static int HeightWithQueue(this Node<int> root)
        {
            // http://stackoverflow.com/a/15015738
            var queue = new Queue<Node<int>>();
            queue.Enqueue(root);
            int height = 0;
            while (queue.Count > 0)
            {
                height++;
                int nodeCount = queue.Count;
                while (nodeCount > 0)
                {
                    var node = queue.Dequeue();
                    foreach (var child in node.Children)
                    {
                        queue.Enqueue(child);
                    }

                    nodeCount--;
                }
            }

            return height;
        }

        // Level order tree traversal
        public static void PrintLevels(this Node<int> root)
        {
            var currentQueue = new Queue<Node<int>>();
            currentQueue.Enqueue(root);
            Console.WriteLine(root.Value);

            int level = 0;

            while (currentQueue.Count != 0)
            {
                var nextQueue = new Queue<Node<int>>();

                level++;

                while (currentQueue.Count != 0)
                {
                    var node = currentQueue.Dequeue();

                    foreach (var child in node.Children)
                    {
                        Console.Write(child.Value + "...");
                        nextQueue.Enqueue(child);
                    }
                }

                Console.WriteLine();
                currentQueue = nextQueue;
            }
        }

        public static void FindSumsTopDown(this Node<int> node, int target, List<Tuple<int, Node<int>>>[] nodeSums)
        {
            // Traverse the children (post-order!)
            foreach (var child in node.Children)
            {
                child.FindSumsTopDown(target, nodeSums);
            }

            // Single node forms a valid path
            nodeSums[node.Value].Add(new Tuple<int, Node<int>>(node.Value, node));
            if (node.Value == target)
            {
                // we have a path   
                var path = ConstructPath<int>(node, node, node);
            }

            // Add this node to sums of children
            foreach (var child in node.Children)
            {
                foreach (var childSum in nodeSums[child.Value])
                {
                    int newSum = childSum.Item1 + node.Value;
                    nodeSums[node.Value].Add(new Tuple<int, Node<int>>(newSum, child));

                    // Have we formed the sum?
                    if (newSum == target)
                    {
                        // we have a path   
                        var path = ConstructPath<int>(node, childSum.Item2, node);
                    }
                }
            }

            // Can we form the sum going through this node and both children?
            for (int i = 0; i < node.Children.Count; i++)
            {
                var child_i = node.Children[i];
                for (int j = i + 1; j < node.Children.Count; j++)
                {
                    var child_j = node.Children[j];
                    foreach (var pair_i in nodeSums[child_i.Value])
                    {
                        foreach (var pair_j in nodeSums[child_j.Value])
                        {
                            if (pair_j.Item1 == target - pair_i.Item1 - node.Value)
                            {
                                // we have a path  
                                var path = ConstructPath<int>(pair_j.Item2, pair_i.Item2, node);
                            }
                        }
                    }
                }
            }

            // We no longer need children sums, free their memory
            foreach (var child in node.Children)
            {
                nodeSums[child.Value] = null;
            }
        }

        public static void FindPathsBottomUp(this Node<int> root, Node<int>[] nodes, int target)
        {
            // For each pair of nodes i,j
            for (int i = 0; i < nodes.Length; i++)
            {
                // If the node equals the sum, this is a solution
                if (nodes[i].Value == target)
                {
                    var path = ConstructPath<int>(nodes[i], nodes[i], nodes[i]);
                }

                for (int j = i + 1; j < nodes.Length; j++)
                {
                    var p = nodes[i];
                    var q = nodes[j];

                    var sums = new Dictionary<Node<int>, int>();
                    int sum_p = 0;
                    int sum_q = 0;

                    // Find the path between the two nodes
                    while (p != null || q != null)
                    {
                        if (p != null)
                        {
                            if (sums.ContainsKey(p))
                            {
                                // We have found the LCA and therefore the path between the two nodes.
                                if (sums[p] + sum_p == target)
                                {
                                    var path = ConstructPath<int>(nodes[i], nodes[j], p);
                                }

                                break;
                            }

                            sum_p += p.Value;
                            sums.Add(p, sum_p);
                            p = p.Parent;
                        }

                        if (q != null)
                        {
                            if (sums.ContainsKey(q))
                            {
                                // We have found the LCA and therefore path between the two nodes.
                                if (sums[q] + sum_q == target)
                                {
                                    var path = ConstructPath<int>(nodes[i], nodes[j], q);
                                }

                                break;
                            }

                            sum_q += q.Value;
                            sums.Add(q, sum_q);
                            q = q.Parent;
                        }
                    }
                }
            }
        }

        public static void PrepLCA(this Node<int> root, int[] lca, int[] levels, int nr, int level, int[] sum)
        {
            // O(N)
            var node = root.Value;
            levels[node] = level;
            sum[node] = node + (root.Parent == null ? 0 : sum[root.Parent.Value]);
            if (levels[node] < nr)
            {
                lca[node] = 1;
            }
            else
            {
                if ((levels[node] % nr) == 0)
                {
                    lca[node] = root.Parent.Value;
                }
                else
                {
                    lca[node] = lca[root.Parent.Value];
                }
            }

            foreach (var child in root.Children)
            {
                child.PrepLCA(lca, levels, nr, level + 1, sum);
            }
        }

        public static int LCA(Node<int>[] nodes, int[] lca, int[] levels, int x, int y)
        {
            // O(sqrt(N)
            while (lca[x] != lca[y])
            {
                if (levels[x] > levels[y])
                {
                    x = lca[x];
                }
                else
                {
                    y = lca[y];
                }
            }

            while (x != y)
            {
                if (levels[x] > levels[y])
                {
                    x = nodes[x].Parent.Value;
                }
                else
                {
                    y = nodes[y].Parent.Value;
                }
            }

            return x;
        }

        public static void FindPathsWithLCA(this Node<int> root, Node<int>[] nodes, int target)
        {
            // Precompute LCAs and Sums
            int nr = (int)Math.Sqrt(root.Height());
            int n = root.NumberOfNodes();
            var lca = new int[n];
            var levels = new int[n];
            var sum = new int[n];
            root.PrepLCA(lca, levels, nr, 0, sum);

            // For each pair of nodes i,j
            for (int i = 0; i < nodes.Length; i++)
            {
                if (i == target)
                {
                    ConstructPath<int>(nodes[i], nodes[i], nodes[i]);
                }

                for (int j = i + 1; j < nodes.Length; j++)
                {
                    var k = LCA(nodes, lca, levels, i, j);
                    if (sum[i] + sum[j] - sum[k] - sum[k] + k == target)
                    {
                        ConstructPath<int>(nodes[i], nodes[j], nodes[k]);
                    }
                }
            }
        }

        private static IEnumerable<T> ConstructPath<T>(Node<T> start, Node<T> end, Node<T> lca)
        {
            var path1 = new LinkedList<T>();
            var path2 = new LinkedList<T>();

            var node = start;
            while (node != lca)
            {
                path1.AddLast(node.Value);
                node = node.Parent;
            }

            path1.AddLast(lca.Value);

            node = end;
            while (node != lca)
            {
                path2.AddFirst(node.Value);
                node = node.Parent;
            }

            // Join the two paths
            foreach (var item in path2)
            {
                path1.AddLast(item);
            }

            Console.WriteLine("Path: {0}", string.Join(" -> ", path1));

            return path1;
        }
    }
}