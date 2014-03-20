using System;
using System.Text;

class CharacterLiterals
{
    static void Main()
    {
        // Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
        //      Hi!
        // Expected output:
        //      \u0048\u0069\u0021

        string str = "Hi!";

        StringBuilder sb = new StringBuilder();
        foreach (char ch in str)
        {
            sb.Append("\\u" + ((int)ch).ToString("X4"));
        }

        Console.WriteLine(sb.ToString());
    }
}