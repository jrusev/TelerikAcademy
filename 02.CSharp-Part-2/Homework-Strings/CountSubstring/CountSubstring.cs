using System;
using System.Text.RegularExpressions;

class CountSubstring
{
    static void Main()
    {
        // Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
        // Example: The target substring is "in". The text is as follows:
        //      We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight.
        //      So we are drinking all the day. We will move out of it in 5 days.
        // The result is: 9.


        string text = @"""We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.""";

        Console.WriteLine(text);

        Console.Write("Type a word or substring to search for: ");
        string substring = Console.ReadLine();

        if (String.IsNullOrEmpty(substring))
        {
            Console.WriteLine("You did not enter anything!");
            return;
        }

        int count = 0;
        int searchIndex = text.IndexOf(substring, StringComparison.OrdinalIgnoreCase);

        if (searchIndex >= 0)
        {
            // We want to highlight all occurences of the substring in the text
            int startIndex = 0;
            while (searchIndex >= 0)
            {
                // Print the text before the substring
                Console.Write(text.Substring(startIndex, searchIndex - startIndex));

                // Print the substring in different color
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(text.Substring(searchIndex, substring.Length));
                Console.ResetColor();
                startIndex = searchIndex + substring.Length;

                count++;
                searchIndex = text.IndexOf(substring, searchIndex + 1, StringComparison.OrdinalIgnoreCase);
            }

            // Print the remaing text after the last substring
            if (startIndex < text.Length - 1)
            {
                Console.Write(text.Substring(startIndex, text.Length - 1 - startIndex)); 
            }

            Console.WriteLine();
        }

        Console.WriteLine("The substring \"{0}\" is contained {1} time{2}.", substring, count, count == 1 ? "" : "s");

        // Check the count with regex in case we did something wrong
        if (count != Regex.Matches(text, substring, RegexOptions.IgnoreCase).Count)
        {
            Console.WriteLine("Error!");
        }
    }
}