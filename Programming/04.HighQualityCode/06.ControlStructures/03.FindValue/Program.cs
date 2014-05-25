using System;

public class Program
{
    public static void Main()
    {
        int[] array = new int[100];
        int searchValue = 0;

        bool isFound = ContainsValue(array, searchValue);

        // More code here
        if (isFound)
        {
            Console.WriteLine("Value Found");
        }
    }

    private static bool ContainsValue(int[] array, int searchValue)
    {
        bool isFound = false;
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
            if (i % 10 == 0 && array[i] == searchValue)
            {
                isFound = true;
                break;
            }
        }

        return isFound;
    }
}
