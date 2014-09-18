using System;

class Salaries
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new string[n];
        for (int i = 0; i < n; i++)
            graph[i] = Console.ReadLine();

        var salaries = new long[n];
        long sum = 0;
        for (int j = 0; j < n; j++)
            sum += FindSalary(graph, j, salaries);

        Console.WriteLine(sum);
    }

    private static long FindSalary(string[] graph, int i, long[] salaries)
    {
        if (salaries[i] > 0) return salaries[i];
        for (int j = 0; j < graph.Length; j++)
            if (graph[i][j] == 'Y')
                salaries[i] += FindSalary(graph, j, salaries);

        salaries[i] = Math.Max(1, salaries[i]);
        return salaries[i];
    }
}
