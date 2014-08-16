using System.Collections;
using System.Collections.Generic;

public class Graph : IEnumerable<List<int>>
{
    public Graph(List<int>[] successorList)
    {
        this.SuccessorList = successorList;
    }

    public List<int>[] SuccessorList { get; private set; }

    public IEnumerator<List<int>> GetEnumerator()
    {
        foreach (var successors in this.SuccessorList)
        {
            yield return successors;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
