using System;
using System.Collections;
using System.Collections.Generic;

public partial class BinarySearchTree<T> : ICloneable, IEnumerable<T>
        where T : IComparable<T>
{
    public static bool operator ==(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
    {
        return BinarySearchTree<T>.Equals(tree1, tree2);
    }

    public static bool operator !=(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
    {
        return !BinarySearchTree<T>.Equals(tree1, tree2);
    }

    public override bool Equals(object obj)
    {
        IEnumerator<T> tree1 = this.GetEnumerator();
        IEnumerator<T> tree2 = (obj as BinarySearchTree<T>).GetEnumerator();

        while (tree1.MoveNext() && tree2.MoveNext())
        {
            if (!tree1.Current.Equals(tree2.Current))
            {
                return false;
            }
        }

        return !tree1.MoveNext() && !tree2.MoveNext();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.Traverse(root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public object Clone()
    {
        BinarySearchTree<T> tree = new BinarySearchTree<T>();

        foreach (T item in this)
        {
            tree.Insert(item);
        }            

        return tree;
    }

    public override int GetHashCode()
    {
        int hash = 17;

        unchecked
        {
            foreach (T item in this)
            {
                hash = (hash * 23) + item.GetHashCode();
            }                
        }

        return hash;
    }

    public override string ToString()
    {
        return string.Join<T>(", ", this);
    }

    private IEnumerable<T> Traverse(BinaryTreeNode<T> root)
    {
        if (root != null)
        {
            foreach (T item in this.Traverse(root.LeftChild))
            {
                yield return item;
            }

            yield return root.Value;

            foreach (T item in this.Traverse(root.RightChild))
            {
                yield return item;
            }
        }
    }
}