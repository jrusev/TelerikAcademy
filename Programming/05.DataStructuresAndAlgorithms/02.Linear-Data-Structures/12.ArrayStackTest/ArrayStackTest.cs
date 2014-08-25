using System;

public class ArrayStackTest
{
    // Implement the ADT stack as auto-resizable array.
    // Resize the capacity on demand (when no space is available to add / insert a new element).
    public static void Main()
    {
        var stack = new ArrayStack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        Console.WriteLine("Stack: {0}", stack);

        stack.Push(5);
        Console.WriteLine("Push 5...");
        Console.WriteLine("Stack: {0}", stack);

        Console.WriteLine("Peek: {0}", stack.Peek());

        Console.WriteLine("Pop: {0}", stack.Pop());
        Console.WriteLine("Stack: {0}", stack);

        Console.WriteLine("Pop: {0}", stack.Pop());
        Console.WriteLine("Stack: {0}", stack);
    }
}
