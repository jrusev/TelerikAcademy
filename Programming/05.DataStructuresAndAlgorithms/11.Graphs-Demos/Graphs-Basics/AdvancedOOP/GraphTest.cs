using System;
using GraphOOP;

public class GraphTest
{
    public static void Main()
    {
        Graph g = new Graph();

        g.AddEdge("A", "B", 14);
        g.AddEdge("A", "C", 10);
        g.AddEdge("A", "D", 14);
        g.AddEdge("A", "E", 21);
        g.AddEdge("B", "C", 9);
        g.AddEdge("B", "E", 10);
        g.AddEdge("B", "F", 14);
        g.AddEdge("C", "D", 9, true); // directed
        g.AddEdge("D", "G", 10, true); // directed
        g.AddEdge("E", "H", 11);
        g.AddEdge("F", "C", 10, true); // directed
        g.AddEdge("F", "H", 10);
        g.AddEdge("F", "I", 9);
        g.AddEdge("G", "F", 8, true); // directed
        g.AddEdge("G", "I", 9);
        g.AddEdge("H", "J", 9);
        g.AddEdge("I", "J", 10);
        g.AddNode("Z"); // no connections

        Console.WriteLine(g);
    }
}