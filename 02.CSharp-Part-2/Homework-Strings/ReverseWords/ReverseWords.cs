using System;
using System.Text;

class ReverseWords
{
    static void Main()
    {
        // Write a program that reverses the words in given sentence.
        // Example:
        //      "C# is not C++, not PHP and not Delphi!"
        // Result:
        //      "Delphi not and PHP, not C++ not is C#!"

        string str = "C# is not C++, not PHP and not Delphi!";
        Console.WriteLine(str);

        // Remove the punctuation at the end of a sentence and split into words
        string[] words = str.Remove(str.Length - 1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder reversed = new StringBuilder();

        // Append the words in reversed order
        for (int i = words.Length - 1; i >= 0; i--)
        {
                reversed.Append(words[i]);
                if (i != 0) reversed.Append(' ');           
        }
        reversed.Append(str[str.Length - 1]); // Add the the punctuation
        Console.WriteLine(reversed);
    }
}