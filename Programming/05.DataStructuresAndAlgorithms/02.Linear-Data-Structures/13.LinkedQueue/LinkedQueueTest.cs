using System;

public class Program
{
    // Implement the ADT queue as dynamic linked list.
    // Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
    public static void Main()
    {
        var queue = new LinkedQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        Console.WriteLine("Queue: {0}", queue);

        queue.Enqueue(5);
        Console.WriteLine("Enqueue 5...");
        Console.WriteLine("Queue: {0}", queue);

        Console.WriteLine("Peek: {0}", queue.Peek());

        Console.WriteLine("Dequeue: {0}", queue.Dequeue());
        Console.WriteLine("Queue: {0}", queue);

        Console.WriteLine("Dequeue: {0}", queue.Dequeue());
        Console.WriteLine("Queue: {0}", queue);
    }
}
