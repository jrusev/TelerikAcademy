using System;

class CompareArrays
{
    static void Main()
    {
        // Write a program that reads two arrays from the console and compares them element by element.
        // (two arrays are equal when they are of equal length and all of their elements, which have the same index, are equal).

        int arraySize = 3;
        Console.WriteLine("Please enter {0} numbers on separate lines:", arraySize);

        float[] arrayA = new float[arraySize];
        for (int i = 0; i < arrayA.Length; i++)
        {
            arrayA[i] = float.Parse(Console.ReadLine());
        }

        Console.WriteLine("Thank you. Now, please enter {0} more numbers:", arraySize);
        float[] arrayB = new float[arraySize];
        for (int i = 0; i < arrayB.Length; i++)
        {
            arrayB[i] = float.Parse(Console.ReadLine());
        }

        bool areEqual = true;
        for (int i = 0; i < arrayA.Length; i++)
        {
            if (arrayA[i] != arrayB[i])
            {
                areEqual = false;
                break;
            }
        }
        Console.WriteLine(areEqual ? "The two arrays are equal." : "The two arrays are not equal!");
    }
}