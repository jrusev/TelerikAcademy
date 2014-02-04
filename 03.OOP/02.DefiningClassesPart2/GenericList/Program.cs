namespace GenericList
{
    using System;

    // Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    // Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    // Implement methods for:
    //      adding element, accessing element by index, removing element by index,
    //      inserting element at given position, clearing the list,
    //      finding element by its value and ToString().
    // Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
    // Create generic methods for finding the minimal and maximal element in the GenericList<T>.
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("> Create new generic list...");
            GenericList<int> list = new GenericList<int>();
            PrintListData(list);

            Console.WriteLine("> Add four items...");
            list = new GenericList<int>(1, 2, 3, 4); // Use the constructor
            PrintListData(list);

            Console.WriteLine("> List is full, add one more item...");
            list.Add(5);
            PrintListData(list);

            Console.WriteLine("> Remove element at index 2...");
            list.RemoveAt(2);
            PrintListData(list);

            Console.WriteLine("> Insert element '3' at index 2...");
            list.InsertAt(3, 2);
            PrintListData(list);

            Console.WriteLine("> Find element '3'...");
            int item = 3;
            int index = list.Find(item);
            Console.WriteLine("Element '{0}' found at index {1}.\n", item, index);

            Console.WriteLine("> Find min and max value...");
            Console.WriteLine("Min: {0}", list.Min());
            Console.WriteLine("Max: {0}\n", list.Max());

            Console.WriteLine(">Clear the list...");
            list.Clear();
            PrintListData(list);
        }

        // Prints count, capacity and list items
        private static void PrintListData(GenericList<int> list)
        {
            Console.WriteLine("Items: {0}", list);
            Console.WriteLine("Count: {0}, Capacity: {1}", list.Count, list.Capacity);
            Console.WriteLine();
        }
    }
}