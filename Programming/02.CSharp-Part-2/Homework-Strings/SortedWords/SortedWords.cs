using System;

class SortedWords
{
    static void Main()
    {
        // Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

        string text = "Write a program that reads a list of words separated by spaces and prints the list in an alphabetical order";
        Console.WriteLine(text);

        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        Console.WriteLine(String.Join("\n",words));
    }
}