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
        BinarySearchTree<string> tree = new BinarySearchTree<string>();
        tree.Insert("Telerik");
        tree.Insert("Google");
        tree.Insert("Microsoft");
        tree.PrintTreeDFS(); // Google Microsoft Telerik
        Console.WriteLine(tree.Contains("Telerik")); // True
        Console.WriteLine(tree.Contains("IBM")); // False
        tree.Remove("Telerik");
        Console.WriteLine(tree.Contains("Telerik")); // False
        tree.PrintTreeDFS(); // Google Microsoft
    }
}