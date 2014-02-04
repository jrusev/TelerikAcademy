namespace GenericList
{
    using System;

    // Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    // Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    // Implement methods for:
    //      adding element, accessing element by index, removing element by index,
    //      inserting element at given position, clearing the list,
    //      finding element by its value and ToString().
    // Check all input parameters to avoid accessing elements at invalid positions.
    // Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
    public class Program
    {
        public static void Main()
        {
            // Create new generic list of integers
            GenericList<int> list = new GenericList<int>();
            PrintListData(list);

            // Add some integers
            list = new GenericList<int>(1, 2, 3, 4); // Use the constructor
            PrintListData(list);

            // The list is full, let's add one more element
            list.Add(5);
            PrintListData(list);

            // Remove element
            list.RemoveAt(2);
            PrintListData(list);

            // Insert element '3' at index 2
            list.InsertAt(3, 2);
            PrintListData(list);

            // Find element '3'
            int item = 3;
            int index = list.Find(item);
            Console.WriteLine("Element '{0}' found at index {1}.\n", item, index);

            // Clear the list
            list.Clear();
            PrintListData(list);
        }

        // Prints count, capacity and list items
        private static void PrintListData(GenericList<int> list)
        {
            Console.WriteLine("Count: {0}, Capacity: {1}", list.Count, list.Capacity);
            Console.WriteLine("Items: {0}", list);
            Console.WriteLine();
        }
    }
}