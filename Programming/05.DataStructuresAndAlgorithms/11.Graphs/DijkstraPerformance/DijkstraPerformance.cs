using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class DijkstraPerformance
{
    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../Tests/test.007.in.txt"));
#endif
        // Read number of nodes, streets and hospitals
        var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int numNodes = parameters[0];
        int numEdges = parameters[1];

        // Create empty graph
        var graph = Enumerable.Range(0, numNodes).Select(i => new List<Neighbor>()).ToArray();

        // Read hospital IDs
        var hospitals = new HashSet<int>(Console.ReadLine().Split(' ').Select(a => int.Parse(a) - 1));

        // Update graph edges
        for (int i = 0; i < numEdges; i++)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int parent = input[0] - 1, child = input[1] - 1;

            graph[parent].Add(new Neighbor() { Id = child, DistTo = input[2] });
            graph[child].Add(new Neighbor() { Id = parent, DistTo = input[2] });
        }

        // For each hospital, sum the shortest distances to each node that is not a hospital
        var minDist = Int32.MaxValue;
        foreach (var id in hospitals)
            minDist = Math.Min(minDist,
               DijkstraFromEmptyQueue(graph, id).Where((dist, i) => !hospitals.Contains(i)).Sum());

        Console.WriteLine(minDist);

        // Dijkstra algorithm performance tests (find shortest paths from all nodes)
        TestPerformance(graph, DijkstraFromEmptyQueue, "DijkstraFromEmptyQueue");
        TestPerformance(graph, DijkstraFromFullQueue, "DijkstraFromFullQueue");
        TestPerformance(graph, DijkstraNoDecr, "DijkstraNoDecr");
        TestPerformance(graph, DijkstraNoPriority, "DijkstraNoPriority");
    }

    private static void TestPerformance(
        IList<Neighbor>[] graph,
        Func<IList<Neighbor>[], int, int[]> algorithm,
        string title)
    {
        Console.Write("{0, -25}", title);
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < graph.Length; i++)
        {
            algorithm(graph, i);
        }
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }

    // Time: 0.626 s
    // E.W. Dijkstra. "A note on two problems in connection with graphs.", 1959
    static int[] DijkstraFromEmptyQueue(IList<Neighbor>[] graph, int source)
    {
        var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
        distances[source] = 0;

        var queue = new IndexMinPQ<int>(graph.Length);
        queue.Enqueue(source, 0);

        while (!queue.IsEmpty())
        {
            int currentNodeId = queue.Dequeue();

            foreach (var neighbour in graph[currentNodeId])
            {
                int newDistance = distances[currentNodeId] + neighbour.DistTo;

                if (newDistance < distances[neighbour.Id])
                {
                    distances[neighbour.Id] = newDistance;

                    if (queue.Contains(neighbour.Id)) queue.DecreasePriority(neighbour.Id, newDistance);
                    else queue.Enqueue(neighbour.Id, newDistance);
                }
            }
        }

        return distances;
    }

    // Time: 0.667 s
    // http://en.wikipedia.org/wiki/Dijkstra's_algorithm#Using_a_priority_queue
    static int[] DijkstraFromFullQueue(IList<Neighbor>[] graph, int source)
    {
        var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
        distances[source] = 0;

        var queue = new IndexMinPQ<int>(graph.Length);
        for (int i = 0; i < graph.Length; i++)
            queue.Enqueue(i, distances[i]);

        while (!queue.IsEmpty())
        {
            int currentNodeId = queue.Dequeue();

            foreach (var neighbour in graph[currentNodeId])
            {
                int newDistance = distances[currentNodeId] + neighbour.DistTo;

                if (newDistance < distances[neighbour.Id])
                {
                    distances[neighbour.Id] = newDistance;
                    queue.DecreasePriority(neighbour.Id, newDistance);
                }
            }
        }

        return distances;
    }

    // Time: 0.721 s
    static int[] DijkstraNoDecr(IList<Neighbor>[] graph, int source)
    {
        var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
        distances[source] = 0;

        var queue = new IndexMinPQ<int>(graph.Length);
        queue.Enqueue(source, 0);

        while (!queue.IsEmpty())
        {
            int currentNodeId = queue.Dequeue();
            foreach (var neighbour in graph[currentNodeId])
            {
                int newDistance = distances[currentNodeId] + neighbour.DistTo;
                if (newDistance < distances[neighbour.Id])
                {
                    distances[neighbour.Id] = newDistance;
                    if (!queue.Contains(neighbour.Id))
                        queue.Enqueue(neighbour.Id, newDistance);
                }
            }
        }

        return distances;
    }

    // Time: 0.732 s
    // Uses System.Collections.Generic.Queue
    static int[] DijkstraNoPriority(IList<Neighbor>[] graph, int source)
    {
        var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
        distances[source] = 0;

        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            int currentNodeId = queue.Dequeue();
            foreach (var neighbour in graph[currentNodeId])
            {
                int newDistance = distances[currentNodeId] + neighbour.DistTo;
                if (newDistance < distances[neighbour.Id])
                {
                    distances[neighbour.Id] = newDistance;
                    queue.Enqueue(neighbour.Id);
                }
            }
        }

        return distances;
    }

    struct Neighbor { public int Id, DistTo; }
}

/// <summary>
/// Indexed priority queue of generic keys.
/// Uses binary heap along with an array to associate keys with integers in the given range.
/// </summary>
/// <typeparam name="T">The type associated with the priority, for example - distance, cost, etc.</typeparam>
public class IndexMinPQ<T> where T : IComparable<T>
{
    private readonly int NMAX; // maximum number of elements on PQ
    private int N; // number of elements on PQ
    private readonly int[] pq; // binary heap using 1-based indexing
    private readonly int[] qp; // inverse of pq - qp[pq[i]] = pq[qp[i]] = i
    private readonly T[] keys; // keys[i] = priority of i

    public IndexMinPQ(int NMAX)
    {
        if (NMAX < 0) throw new ArgumentException();

        this.NMAX = NMAX;

        keys = new T[NMAX + 1];
        pq = new int[NMAX + 1];
        qp = new int[NMAX + 1];

        for (int i = 0; i <= NMAX; i++)
            qp[i] = -1;
    }

    public bool IsEmpty()
    {
        return N == 0;
    }

    public bool Contains(int i)
    {
        if (i < 0 || i >= NMAX) throw new ArgumentOutOfRangeException();

        return qp[i] != -1;
    }

    public void Enqueue(int index, T priority)
    {
        if (index < 0 || index >= NMAX) throw new ArgumentOutOfRangeException();
        if (Contains(index)) throw new ArgumentException("index is already in the priority queue");
        N++;
        qp[index] = N;
        pq[N] = index;
        keys[index] = priority;
        Swim(N);
    }

    public T Peek()
    {
        if (N == 0) throw new KeyNotFoundException("Priority queue underflow");
        return keys[pq[1]];
    }

    public int Dequeue()
    {
        if (N == 0) throw new KeyNotFoundException("Priority queue underflow");
        int min = pq[1];
        Swap(1, N--);
        Sink(1);
        qp[min] = -1; // delete
        keys[pq[N + 1]] = default(T); // to help with garbage collection
        pq[N + 1] = -1; // not needed
        return min;
    }

    public void DecreasePriority(int index, T priority)
    {
        if (index < 0 || index >= NMAX) throw new ArgumentOutOfRangeException();
        if (!Contains(index)) throw new KeyNotFoundException("index is not in the priority queue");
        if (keys[index].CompareTo(priority) <= 0) throw new ArgumentException("Calling decreaseKey() with given argument would not strictly decrease the key");
        keys[index] = priority;
        Swim(qp[index]);
    }

    private bool Greater(int i, int j)
    {
        return keys[pq[i]].CompareTo(keys[pq[j]]) > 0;
    }

    private void Swap(int i, int j)
    {
        int swap = pq[i];
        pq[i] = pq[j];
        pq[j] = swap;
        qp[pq[i]] = i;
        qp[pq[j]] = j;
    }

    private void Swim(int k)
    {
        while (k > 1 && Greater(k / 2, k))
        {
            Swap(k, k / 2);
            k = k / 2;
        }
    }

    private void Sink(int k)
    {
        while (2 * k <= N)
        {
            int j = 2 * k;
            if (j < N && Greater(j, j + 1)) j++;
            if (!Greater(k, j)) break;
            Swap(k, j);
            k = j;
        }
    }
}
