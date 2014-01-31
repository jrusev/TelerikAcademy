using System;

class RemoveRepeatingLetters
{
    static void Main()
    {
        // Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
        // Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".

        Console.WriteLine("Please enter some random letters, like so: aaaaabbbbbcdddeeeedssaa.");
        Console.Write(">");
        string str = Console.ReadLine();

        //string str = "aaaaabbbbbcdddeeeedssaa";

        if (str.Length < 2)
        {
            Console.WriteLine("There are no repeating letters.");
        }
        else
        {
            Console.Write(str[0]);
            for (int i = 1; i < str.Length; i++)
            {
                // Compare each symbol with the one before it
                if (str[i] != str[i - 1])
                {
                    Console.Write(str[i]);
                }
            }
            Console.WriteLine();
        }
    }
}