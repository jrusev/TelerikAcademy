using System;

class ReverseString
{
    static void Main()
    {
        // Write a program that reads a string, reverses it and prints the result at the console.
        // Example: "sample" -> "elpmas".

        Console.Write("Please enter your name: ");
        string str = Console.ReadLine();

        Console.Write("Reversed: ");

        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }

        Console.WriteLine();
    }
}
