using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node),
// each in the range (0..N-1). Write a program to read the tree and find:
// 
// 1) the root node
// 2) all leaf nodes
// 3) all middle nodes
// 4) the longest path in the tree
// 5) all paths in the tree with given sum S of their nodes
// 6) all subtrees with given sum S of their nodes
//          ________3________
//          |               |
//  ________5________       2
//  |       |       |       |
//  0       1       6       4
public class Program
{
    private static Node<int>[] nodes;

    private static void Main()
    {
        // Example tree, N-1 pairs of (parent node - child node)
        Console.SetIn(new StringReader(@"7
2 4
3 2
5 0
3 5
5 6
5 1
"));

        ParseTree(Console.In);

        // 1) the root node
        var root = FindRoot();
        root.PrintTree();
        Console.WriteLine("1) Root: {0}", root.Value);

        // 2) all leaf nodes
        var leafNodes = FindLeafNodes();
        Console.WriteLine("2) Leaf nodes: {0}", string.Join(", ", leafNodes));

        // 3) all middle nodes
        var middleNodes = FindMiddleNodes();
        Console.WriteLine("3) Middle nodes: {0}", string.Join(", ", middleNodes));

        // 4) the longest path in the tree
        var longestPath = FindLongestPath(root);
        Console.WriteLine("4) Longest path (through the root): {0}", string.Join(", ", longestPath));

        // 5) all paths in the tree with given sum S of their nodes
        int pathSum = 6;
        Console.WriteLine("5) Paths with sum {0} of their nodes:", pathSum);
        FindPathsWithSum(nodes, pathSum);

        // 6) all subtrees with given sum S of their nodes
        int treeSum = 6;
        Console.WriteLine("6) Trees with sum {0} of their nodes:", treeSum);
        FindSubTreesSum(root, treeSum);
    }

    private static Node<int> FindRoot()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            if (!nodes[i].HasParent)
            {
                return nodes[i];
            }
        }

        throw new ApplicationException("The tree has no root!");
    }

    private static IEnumerable<int> FindLeafNodes()
    {
        var leafNodes = new List<int>();
        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].Children.Count == 0)
            {
                leafNodes.Add(nodes[i].Value);
            }
        }

        return leafNodes;
    }

    private static IEnumerable<int> FindMiddleNodes()
    {
        var middleNodes = new List<int>();
        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].Children.Count != 0 && nodes[i].HasParent)
            {
                middleNodes.Add(nodes[i].Value);
            }
        }

        return middleNodes;
    }

    private static IEnumerable<int> FindLongestPath(Node<int> root)
    {
        var firstPath = new List<Node<int>>();
        var secondPath = new List<Node<int>>();

        foreach (var child in root.Children)
        {
            var currentPath = MaxPathNodeToLeaf(child);
            if (currentPath.Count > secondPath.Count)
            {
                if (currentPath.Count > firstPath.Count)
                {
                    secondPath = firstPath;
                    firstPath = currentPath;
                }
                else
                {
                    secondPath = currentPath;
                }
            }
        }

        var longestPath = new List<int>();

        for (int i = secondPath.Count - 1; i >= 0; i--)
        {
            longestPath.Add(secondPath[i].Value);
        }

        longestPath.Add(root.Value);

        foreach (var item in firstPath)
        {
            longestPath.Add(item.Value);
        }

        return longestPath;
    }

    private static List<Node<int>> MaxPathNodeToLeaf(Node<int> root)
    {
        var longestPath = new List<Node<int>>();

        var path = new List<Node<int>>();
        path.Add(root);

        var stack = new Stack<List<Node<int>>>();
        stack.Push(path);

        while (stack.Count != 0)
        {
            var currentPath = stack.Pop();
            var lastNode = currentPath[currentPath.Count - 1];

            foreach (var child in lastNode.Children)
            {
                var newPath = new List<Node<int>>(currentPath);
                newPath.Add(child);
                stack.Push(newPath);
            }

            if (currentPath.Count > longestPath.Count)
            {
                longestPath = currentPath;
            }
        }

        return longestPath;
    }

    private static void FindPathsWithSum(Node<int>[] nodes, int targetSum)
    {
        var startNode = new bool[nodes.Length];
        foreach (var node in nodes)
        {
            startNode[node.Value] = true;
            FindPathsFromNode(node, 0, targetSum, new Stack<int>(), node, startNode);
        }
    }

    private static void FindPathsFromNode(
        Node<int> root, int sum, int target, Stack<int> path, Node<int> previous, bool[] start)
    {
        path.Push(root.Value);
        sum += root.Value;
        if (sum >= target)
        {
            if (sum == target && (path.Count == 1 || !start[root.Value]))
                Console.WriteLine("Path: {0}", string.Join(" -> ", path));
        }
        else
        {
            foreach (var child in root.Children.Where(c => c != previous))
                FindPathsFromNode(child, sum, target, path, root, start);
            if (root.Parent != null && root.Parent != previous)
                FindPathsFromNode(root.Parent, sum, target, path, root, start);
        }
        path.Pop();
    }

    private static int FindSubTreesSum(Node<int> root, int target)
    {
        int sum = root.Value;
        foreach (var child in root.Children) sum += FindSubTreesSum(child, target);
        if (sum == target) root.PrintTree();
        return sum;
    }

    private static void ParseTree(TextReader input)
    {
        int n = int.Parse(input.ReadLine());

        nodes = new Node<int>[n];

        // Create the nodes with their corresponding values
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = new Node<int>(i);
        }

        // Add the edges
        for (int i = 0; i < n - 1; i++)
        {
            string[] vertices = input.ReadLine().Split(
                new char[] { ' ', '(', ')', '-', '>', '<' }, StringSplitOptions.RemoveEmptyEntries);
            int parentIndex = int.Parse(vertices[0]);
            int childIndex = int.Parse(vertices[1]);

            var child = nodes[childIndex];
            var parent = nodes[parentIndex];

            parent.Children.Add(child);
            child.Parent = parent;
        }
    }
}
