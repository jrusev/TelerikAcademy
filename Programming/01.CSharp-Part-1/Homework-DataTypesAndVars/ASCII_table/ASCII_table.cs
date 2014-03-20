using System;

class ASCII_table
{
    static void Main()
    {
        // Write a program that prints the entire ASCII table of characters on the console.
        Console.WriteLine("Dec\tChar");
        for (int i = 32; i <= 126; i++) // only the printable characters (letters, digits, punctuation marks, etc.)
        {
            Console.WriteLine(i + "\t" +(char)i);
        }
    }
}
          