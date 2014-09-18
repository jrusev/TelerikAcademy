//Finding and printing an Euler cycle in a Undirected graph

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class EulerCycle
{
    public static string sampleInput = @"6
011110
101101
110011
110011
101101
011110
";

    public static string sampleInput2 = @"6
000110
001001
010001
100010
100100
011000
";

    public static string sampleInput3 = @"6
000110
001101
010001
110011
100100
011100
";

    public static string sampleInput4 = @"4
0101
1010
0101
1010
";

    public static string sampleInput5 = @"6
010111
101000
010100
101000
100001
100010
";

    static void Main()
    {
        Console.Write(sampleInput);
        PrintEulerCycleInUndirectedGraph(sampleInput);

        Console.WriteLine();

        Console.Write(sampleInput2);
        PrintEulerCycleInUndirectedGraph(sampleInput2);

        Console.WriteLine();

        Console.Write(sampleInput3);
        PrintEulerCycleInUndirectedGraph(sampleInput3);

        Console.WriteLine();

        Console.Write(sampleInput4);
        PrintEulerCycleInUndirectedGraph(sampleInput4);

        Console.WriteLine();

        Console.Write(sampleInput5);
        PrintEulerCycleInUndirectedGraph(sampleInput5);
    }

    private static void PrintEulerCycleInUndirectedGraph(string input)
    {
        //Representing the graph with the neighbours(edges) keeped for each vertex
        HashSet<int>[] vertexNeighbours;

        //Getting the input
        int edgesLeft = 0;
        bool isEulerCandidate = true;
        ReadSampleInput(input, out vertexNeighbours, ref edgesLeft, ref isEulerCandidate);

        //Euler cycle is only possible when all vertices are of even degree.
        if (!isEulerCandidate)
        {
            Console.WriteLine("No Euler cycles because of a vertex with odd degree!");
            return;
        }

        Stack<int> tempPath = new Stack<int>();
        Stack<int> finalPath = new Stack<int>();

        //Choose the vertex to start with
        for (int i = 0; i < vertexNeighbours.Length; i++)
        {
            if (vertexNeighbours[i].Count > 0)
            {
                tempPath.Push(i);
                break;
            }
        }

        int next;
        while (edgesLeft > 0)
        {
            if (vertexNeighbours[tempPath.Peek()].Count > 0)
            {
                //There is unvisited edge from current vertex leading to the next vertex
                next = vertexNeighbours[tempPath.Peek()].First<int>();

                //Removing both edges because the graph is not-oriented
                vertexNeighbours[tempPath.Peek()].Remove(next);
                vertexNeighbours[next].Remove(tempPath.Peek());
                edgesLeft -= 2;

                //Moving to the next vertex
                tempPath.Push(next);
            }
            else
            {
                //Small cycle finished
                finalPath.Push(tempPath.Pop());
            }

            //No way to go from passed vertices but there are still edges left, so the graph is not connected
            if (tempPath.Count == 0)
            {
                Console.WriteLine("There is no Euler cycle because the graph is not connected!");
                return;
            }
        }

        //Adding final left vertices to finalPath
        while (tempPath.Count > 0) finalPath.Push(tempPath.Pop());

        Console.WriteLine("Printing Euler cycle:");
        while (finalPath.Count > 0) Console.Write("{0} ", finalPath.Pop());
        Console.WriteLine();
    }

    private static void ReadSampleInput
        (string input, out HashSet<int>[] vertexNeighbours, ref int edgesLeft, ref bool isEulerCandidate)
    {
        StringReader reader = new StringReader(input);
        using (reader)
        {
            int n = int.Parse(reader.ReadLine().Trim());
            vertexNeighbours = new HashSet<int>[n];
            string line;
            for (int i = 0; i < n; i++)
            {
                vertexNeighbours[i] = new HashSet<int>();
                line = reader.ReadLine().Trim();
                for (int j = 0; j < n; j++)
                {
                    if (line[j] == '1') vertexNeighbours[i].Add(j);
                }
                edgesLeft += vertexNeighbours[i].Count;
                if (vertexNeighbours[i].Count % 2 != 0)
                {
                    isEulerCandidate = false;
                    return;
                }
            }
        }
    }
}