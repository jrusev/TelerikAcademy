using System;

class ForbiddenWords
{
    static void Main()
    {
        /*
         * We are given a string containing a list of forbidden words and a text containing some of these words.
         * Write a program that replaces the forbidden words with asterisks.
         * Example:
         *      Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
         *  Words: "PHP, CLR, Microsoft"
         * 	The expected result:
         * 		********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
         */

        string forbidden = "PHP, CLR, Microsoft";
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        Console.WriteLine(text);

        string[] forbiddenWords = forbidden.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in forbiddenWords)
        {
            string word = item.Trim();
            text = text.Replace(word, new String('*', word.Length));
        }

        Console.WriteLine('\n' + text);
    }
}