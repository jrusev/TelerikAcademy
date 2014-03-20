using System;

class HelloName
{
    static void Main()
    {
        // Write a method that asks the user for his name
        // and prints “Hello, <name>” (for example, “Hello, Peter!”).
        // Write a program to test this method.

        string firstName = GetName();

        while (!IsValidName(firstName)) // checks if all symbols are Unicode letters
        {
            Console.WriteLine("You did not enter a correct name!");
            firstName = GetName();
        }
        PrintHello(firstName);
    }

    static string GetName()
    {
        Console.Write("Please enter your first name: ");
        return Console.ReadLine();
    }

    static void PrintHello(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }

    static bool IsValidName(string name)
    {
        foreach (var symbol in name)
            if (!Char.IsLetter(symbol)) return false;

        return true;
    }
}