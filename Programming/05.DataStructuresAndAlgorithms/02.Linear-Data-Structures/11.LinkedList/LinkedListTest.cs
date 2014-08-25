using System;

public class LinkedListTest
{
    // Implement the data structure linked list. 
    public static void Main()
    {
        var linkedList = new LinkedList<string>();

        linkedList.AddFirst("first");
        linkedList.AddLast("second");
        Console.WriteLine(string.Join(", ", linkedList));

        linkedList.Clear();
        linkedList.AddLast("second");
        linkedList.AddFirst("first");
        Console.WriteLine(string.Join(", ", linkedList));

        string value = "first";
        Console.WriteLine("List contains \"{0}\": {1}", value, linkedList.Contains(value));

        Console.WriteLine("List contains {0} item(s)", linkedList.Count);

        var item = linkedList.Find("second");
        Console.WriteLine(item);

        linkedList.Remove("first");
        Console.WriteLine(string.Join(", ", linkedList));

        linkedList.Remove("second");
        Console.WriteLine("List contains {0} item(s): {1}", linkedList.Count, string.Join(", ", linkedList));

        linkedList.AddFirst("second");
        linkedList.AddFirst("first");
        linkedList.AddLast("third");
        Console.WriteLine(string.Join(", ", linkedList));

        linkedList.Remove("second");
        Console.WriteLine(string.Join(", ", linkedList));
    }
}