using System;

public class Program
{
    public static void Main()
    {
        int[] array = new int[100];
        int expectedValue = 0;

        bool isFound = FindValue(array, expectedValue);

        // More code here
        if (isFound)
        {
            Console.WriteLine("Value Found");
        }
    }

    private static bool FindValue(int[] array, int expectedValue)
    {
        bool isFound = false;
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
            if (i % 10 == 0 && array[i] == expectedValue)
            {
                isFound = true;
            }
        }

        return isFound;
    }
}
