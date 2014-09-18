using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    private static readonly IDictionary<char, Node> nodes = new SortedDictionary<char, Node>();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var message = Console.ReadLine();
            var root = GetOrCreateNode(message[0]);

            for (int j = 1; j < message.Length; j++)
            {
                var child = GetOrCreateNode(message[j]);
                root.Children.Add(child);
                child.Parents.Add(root);
                root = child;
            }
        }

        Console.WriteLine(RecoverMessage());
    }

    // Topological sorting
    static string RecoverMessage()
    {
        var output = new StringBuilder();
        
        while (nodes.Count > 0)
        {
            var root = nodes.Values.First(a => a.Parents.Count == 0);
            output.Append(root.Value);

            foreach (var child in root.Children)
                child.Parents.Remove(root);

            nodes.Remove(root.Value);
        }

        return output.ToString();
    }

    static Node GetOrCreateNode(char key)
    {
        Node node;
        nodes.TryGetValue(key, out node);

        if (node == null)
        {
            node = new Node(key);
            nodes[key] = node;
        }

        return node;
    }

    public class Node : IComparable<Node>
    {
        public Node(char letter)
        {
            this.Value = letter;
            this.Parents = new SortedSet<Node>();
            this.Children = new SortedSet<Node>();
        }

        public char Value { get; set; }

        public SortedSet<Node> Parents { get; set; }

        public SortedSet<Node> Children { get; set; }

        public int CompareTo(Node other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}