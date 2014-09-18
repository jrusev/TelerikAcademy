using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static readonly int initialNode = 0;

    static readonly List<string> allPaths = new List<string>();
    static readonly IList<int> path = new List<int>();

    static int[,] adjMatrix;
    static int n;
    static int connections;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        adjMatrix = new int[n, n];

        bool isEulerCandidate = InitializeMatrix();

        if (isEulerCandidate)
            FindAllEulearCycles(initialNode);

        PrintResult();
    }

    static bool InitializeMatrix()
    {
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();

            for (int j = 0; j < n; j++)
                connections += (adjMatrix[i, j] = input[j] - '0');

            if (connections % 2 != 0) return false;
        }

        return true;
    }

    static void FindAllEulearCycles(int i)
    {
        if (path.Count == connections / 2)
        {
            allPaths.Add(string.Join(" ", path));
            return;
        }

        for (int j = 0; j < n; j++)
        {
            if (adjMatrix[i, j] > 0)
            {
                adjMatrix[i, j] = adjMatrix[j, i] *= -1;
                path.Add(j);

                FindAllEulearCycles(j);

                path.RemoveAt(path.Count - 1);
                adjMatrix[i, j] = adjMatrix[j, i] *= -1;
            }
        }
    }

    static void PrintResult()
    {
        var result = new StringBuilder();

        for (int i = 0; i < allPaths.Count; i++)
            result.AppendFormat("Route {0}: {1} {2}\n", i + 1, initialNode, allPaths[i]);

        Console.Write(result);
        Console.WriteLine("Number of routes: {0}", allPaths.Count);
    }
}