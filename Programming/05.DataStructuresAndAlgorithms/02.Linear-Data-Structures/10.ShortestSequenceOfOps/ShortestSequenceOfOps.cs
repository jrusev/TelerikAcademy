using System;
using System.Collections.Generic;
using System.Linq;

public class ShortestSequenceOfOps
{
    // We are given numbers N and M and the following operations:
    //  N = N+1
    //  N = N+2
    //  N = N*2
    // Write a program that finds the shortest sequence of operations
    // that starts from N and finishes in M. Hint: use a queue.
    // Example: N = 5, M = 16
    // Sequence: 5 -> 7 -> 8 -> 16
    private static void Main()
    {
        int n = 5;
        int m = 16; // 1048575

        // Operations are stored in an array so we can iterate over them in a cycle.
        Func<int, int>[] operations = 
        {
            x => x + 1,
            x => x + 2,
            x => x * 2,
        };

        var sequence = ShortestSequence(n, m, operations);
        Console.WriteLine(string.Join(" -> ", sequence));
    }

    /// <summary>
    /// Traverses the solution tree (all possible operations) by using BFS with queue.
    /// Stops when the end number is reached.
    /// There are two optimizations - discards numbers greater than the end number,
    /// and skips numbers that have already been processed (to avoid repeating branches).
    /// The numbers are stored in a node structure, where each number has a parent (except the first).
    /// The numbers already visited are stored in a hash table, so we can quickly check them.
    /// </summary>
    /// <param name="n">The start number.</param>
    /// <param name="m">The end number.</param>
    private static IEnumerable<int> ShortestSequence(int n, int m, Func<int, int>[] operations)
    {
        var queue = new Queue<Node>();
        var visited = new HashSet<int>();
        bool finished = false;

        queue.Enqueue(new Node(n));
        while (!finished)
        {
            var currentNode = queue.Dequeue();
            int value = currentNode.Value;

            foreach (var operation in operations)
            {
                int next = operation(value);
                if (next <= m && !visited.Contains(next))
                {
                    queue.Enqueue(new Node(next, currentNode));
                    visited.Add(next);
                    if (next == m)
                    {
                        finished = true;
                        break;
                    }
                }
            }
        }

        return GetSequence(queue.Last());
    }

    /// <summary>
    /// Extracts the sequence of numbers by going back through each node's parent
    /// until it gets to the first node, which has no parent.
    /// </summary>
    private static IEnumerable<int> GetSequence(Node node)
    {
        var stack = new Stack<int>();
        while (node != null)
        {
            stack.Push(node.Value);
            node = node.Parent;
        }

        return stack;
    }

    /// <summary>
    /// A tree node, that holds an integer as Value, and has a Parent another Node.
    /// </summary>
    private class Node
    {
        public Node(int value, Node parent = null)
        {
            this.Value = value;
            this.Parent = parent;
        }

        public int Value { get; set; }

        public Node Parent { get; set; }
    }
}