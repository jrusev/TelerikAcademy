using System;

class AsteriskAdding
{
    static void Main()
    {
        // Write a program that reads from the console a string of maximum 20 characters.
        // If the length of the string is less than 20, the rest of the characters should be filled with '*'.
        // Print the result string into the console.

        Console.Write("Please enter a string with maximum 20 characters: ");
        string str = Console.ReadLine();

        while (str.Length > 20)
        {
            Console.Write("Enter no more than 20 symbols: ");
            str = Console.ReadLine();
        }

        str = str + new String('*', 20 - str.Length);
        Console.WriteLine(str);

    }
}
