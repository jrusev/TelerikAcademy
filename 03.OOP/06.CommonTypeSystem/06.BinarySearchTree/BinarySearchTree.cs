using System;
using System.Collections.Generic;

public partial class BinarySearchTree<T> : ICloneable, IEnumerable<T>
        where T : IComparable<T>, IEquatable<T>
{
    // The root of the tree
    private BinaryTreeNode<T> root;

    /// <summary>
    /// Constructs the tree
    /// </summary>
    public BinarySearchTree()
    {
        this.root = null;
    }

    /// <summary>Inserts new value in the binary search tree
    /// </summary>
    /// <param name="value">the value to be inserted</param>
    public void Insert(T value)
    {
        this.root = this.Insert(value, null, this.root);
    }

    /// <summary>Returns whether given value exists in the tree
    /// </summary>
    /// <param name="value">the value to be checked</param>
    /// <returns>true if the value is found in the tree</returns>
    public bool Contains(T value)
    {
        bool found = this.Find(value) != null;
        return found;
    }

    /// <summary>Removes an element from the tree if exists
    /// </summary>
    /// <param name="value">the value to be deleted</param>
    public void Remove(T value)
    {
        BinaryTreeNode<T> nodeToDelete = this.Find(value);
        if (nodeToDelete != null)
        {
            this.Remove(nodeToDelete);
        }
    }

    /// <summary>Traverses and prints the tree</summary>
    public void PrintTreeDFS()
    {
        this.PrintTreeDFS(this.root);
        Console.WriteLine();
    }

    /// <summary>
    /// Inserts node in the binary search tree by given value
    /// </summary>
    /// <param name="value">the new value</param>
    /// <param name="parentNode">the parent of the new node</param>
    /// <param name="node">current node</param>
    /// <returns>the inserted node</returns>
    private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
    {
        if (node == null)
        {
            node = new BinaryTreeNode<T>(value);
            node.Parent = parentNode;
        }
        else
        {
            int compareTo = value.CompareTo(node.Value);
            if (compareTo < 0)
            {
                node.LeftChild =
                this.Insert(value, node, node.LeftChild);
            }
            else if (compareTo > 0)
            {
                node.RightChild =
                this.Insert(value, node, node.RightChild);
            }
        }

        return node;
    }

    // Finds a given value in the tree and returns the node which contains it if such exsists
    private BinaryTreeNode<T> Find(T value)
    {
        BinaryTreeNode<T> node = this.root;
        while (node != null)
        {
            int compareTo = value.CompareTo(node.Value);
            if (compareTo < 0)
            {
                node = node.LeftChild;
            }
            else if (compareTo > 0)
            {
                node = node.RightChild;
            }
            else
            {
                break;
            }
        }

        return node;
    }

    private void Remove(BinaryTreeNode<T> node)
    {
        // Case 3: If the node has two children.
        // Note that if we get here at the end
        // the node will be with at most one child
        if (node.LeftChild != null && node.RightChild != null)
        {
            BinaryTreeNode<T> replacement = node.RightChild;
            while (replacement.LeftChild != null)
            {
                replacement = replacement.LeftChild;
            }

            node.Value = replacement.Value;
            node = replacement;
        }

        // Case 1 and 2: If the node has at most one child
        BinaryTreeNode<T> theChild = node.LeftChild != null ?
        node.LeftChild : node.RightChild;

        // If the element to be deleted has one child
        if (theChild != null)
        {
            theChild.Parent = node.Parent;

            // Handle the case when the element is the root
            if (node.Parent == null)
            {
                this.root = theChild;
            }
            else
            {
                // Replace the element with its child sub-tree
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = theChild;
                }
                else
                {
                    node.Parent.RightChild = theChild;
                }
            }
        }
        else
        {
            // Handle the case when the element is the root
            if (node.Parent == null)
            {
                this.root = null;
            }
            else
            {
                // Remove the element - it is a leaf
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = null;
                }
                else
                {
                    node.Parent.RightChild = null;
                }
            }
        }
    }

    // Traverses and prints the ordered binary search tree starting from given root node.
    private void PrintTreeDFS(BinaryTreeNode<T> startNode)
    {
        if (startNode != null)
        {
            this.PrintTreeDFS(startNode.LeftChild);
            Console.Write(startNode.Value + " ");
            this.PrintTreeDFS(startNode.RightChild);
        }
    }
}