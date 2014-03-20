using System;

internal class Program
{
    // Define the data structure binary search tree with operations for
    // "adding new element", "searching element" and "deleting elements".
    // Implement the standard methods from System.Object – ToString(), Equals(…), GetHashCode()
    // and the operators for comparison  == and !=.
    // Add and implement the ICloneable interface for deep copy of the tree.
    // Implement IEnumerable<T> to traverse the tree.
    internal static void Main()
    {
        // Create new binary search tree
        BinarySearchTree<string> tree = new BinarySearchTree<string>();

        // Test adding new element
        tree.Insert("Telerik");
        tree.Insert("Google");
        tree.Insert("Microsoft");
        tree.Insert("Facebook");
        tree.Insert("Twitter");

        // Test ToString()
        Console.WriteLine("Tree: {0}", tree);

        // Test searching element
        Console.WriteLine("Tree contains Telerik? -> {0}", tree.Contains("Telerik"));
        Console.WriteLine("Tree contains IBM? -> {0}", tree.Contains("IBM"));

        // Test deleting element
        tree.Remove("Telerik");
        Console.WriteLine("Tree: remove Telerik");
        Console.WriteLine("Tree: {0}", tree);

        // Test GetHashCode
        Console.WriteLine("Tree hash code = {0}", tree.GetHashCode());

        // Test Equals
        var otherTree = new BinarySearchTree<string>();
        otherTree.Insert("Google");
        Console.WriteLine("\nOther tree: {0}", otherTree);
        Console.WriteLine("tree.Equals(otherTree) -> {0}", tree.Equals(otherTree));

        // Test '=='
        Console.WriteLine("Other tree: insert Microsoft, Facebook, Twitter");
        otherTree.Insert("Microsoft");
        otherTree.Insert("Facebook");
        otherTree.Insert("Twitter");
        Console.WriteLine("Other tree: {0}", otherTree);
        Console.WriteLine("tree.Equals(otherTree) -> {0}", tree.Equals(otherTree));

        // Test IEnumerable<T> to traverse the tree
        Console.WriteLine("\nforeach (var node in tree):");
        foreach (var node in tree)
        {
            Console.WriteLine(node);
        }

        // Test deep copy of the tree.
        var treeClone = tree.Clone();
        Console.WriteLine("\ntreeClone: {0}", treeClone);
        tree.Remove("Google");
        Console.WriteLine("Original tree: remove Google");
        Console.WriteLine("treeClone: {0}", treeClone);
    }
}