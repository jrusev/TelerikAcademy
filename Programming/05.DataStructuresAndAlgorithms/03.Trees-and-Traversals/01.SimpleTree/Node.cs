using System;
using System.Collections.Generic;

// Represents a tree node
public class Node<T>
{
    public Node(T value, Node<T> parent = null)
    {
        this.Value = value;
        this.Children = new List<Node<T>>();
        this.Parent = parent;
    }

    public bool HasParent
    { 
        get
        {
            return this.Parent != null;
        }
    }

    public T Value { get; set; }

    public List<Node<T>> Children { get; private set; }

    public Node<T> Parent { get; set; }

    public override string ToString()
    {
        return this.Value.ToString();
    }

    // Iterates over the children and parent of the node
    public IEnumerable<Node<T>> Adjacent()
    {
        if (this.Parent != null) yield return this.Parent;
        foreach (var child in this.Children) yield return child;
    }

    // Prints the node and all its children
    public void PrintTree()
    {
        Console.WriteLine("Tree");
        this.Print(string.Empty, true);
    }

    // Prints the nodes recursively
    private void Print(string prefix, bool isTail)
    {
        Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + this.Value);
        for (int i = 0; i < this.Children.Count - 1; i++)
        {
            this.Children[i].Print(prefix + (isTail ? "    " : "│   "), false);
        }

        if (this.Children.Count >= 1)
        {
            this.Children[this.Children.Count - 1].Print(prefix + (isTail ? "    " : "│   "), true);
        }
    }
}
