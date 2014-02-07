using System;
using System.Text;

// Implement an extension method Substring(int index, int length) for the class StringBuilder
// that returns new StringBuilder and has the same functionality as Substring in the class String.
public class Program
{
    public static void Main()
    {
        StringBuilder sb = new StringBuilder("Take a substring from me using an extension method.");
        Console.WriteLine(sb);

        StringBuilder subString = sb.Substring(34, 16);
        Console.WriteLine(subString);
    }
}