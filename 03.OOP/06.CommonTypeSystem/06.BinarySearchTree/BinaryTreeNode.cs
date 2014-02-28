using System;

public partial class BinarySearchTree<T> where T : IComparable<T>
{
    /// <summary>Represents a binary tree node</summary>
    /// <typeparam name="T">The type of the nodes</typeparam>
    internal class BinaryTreeNode<T> :
        IComparable<BinaryTreeNode<T>> where T : IComparable<T>
    {
        /// <summary>Constructs the tree node</summary>
        /// <param name="value">The value of the tree node</param>
        public BinaryTreeNode(T value)
        {
            if (value == null)
            {
                // Null values cannot be compared -> do not allow them
                throw new ArgumentNullException( "Cannot insert null value!");
            }

            this.Value = value;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
        }

        // Contains the value of the node
        internal T Value { get; set; }

        // Contains the parent of the node
        internal BinaryTreeNode<T> Parent { get; set; }

        // Contains the left child of the node
        internal BinaryTreeNode<T> LeftChild { get; set; }

        // Contains the right child of the node
        internal BinaryTreeNode<T> RightChild { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(BinaryTreeNode<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }  
}