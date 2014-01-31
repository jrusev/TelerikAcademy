using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class TagsToUpper
{
    static void Main()
    {
        // You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase.
        // The tags cannot be nested.
        // Example:
        // We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
        // Result:
        // We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

        string text = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Console.WriteLine(text);

        string openTag = "<upcase>";
        string closeTag = "</upcase>";
        string parsed = ParseText(text, openTag, closeTag); // Without regex

        Console.WriteLine("Parsed text:");
        Console.WriteLine(parsed);

        //SpeedTest();
    }

    // Finds the text bewteen the tags and performs some transofmration on it (in this case ToUpper)
    static string ParseText(string text, string openTag, string closeTag)
    {
        if (String.IsNullOrEmpty(text))
            return String.Empty;

        StringBuilder parsed = new StringBuilder();

        // Read each character
        for (int i = 0; i < text.Length; i++)
        {
            // Check if open tag begins
            if (text[i] == '<')
            {
                // Skip the open tag
                i += openTag.Length;

                // Inside tag

                // Until a close tag begins
                while (text[i] != '<')
                {
                    // Do something with the tagged text here
                    parsed.Append(Char.ToUpper(text[i++]));
                }

                // Skip the close tag
                i += closeTag.Length - 1;
            }
            else // Outside tag
            {
                parsed.Append(text[i]);
            }
        }

        return parsed.ToString();
    }

    // Finds the text bewteen the tags and performs some transofmration on it using regex
    static string ParseTextRegex(string text, string openTag, string closeTag)
    {
        if (String.IsNullOrEmpty(text))
            return String.Empty;

        string regex = openTag + "(.*?)" + closeTag;
        return Regex.Replace(text, regex, m => m.Groups[1].Value.ToUpper());
    }

    // Comparaes the speed of two parsing methods
    static void SpeedTest()
    {
        string openTag = "<upcase>";
        string closeTag = "</upcase>";

        // Generate random text with some tags 
        string longText = GenerateRandomText(openTag, closeTag);

        // Check if text can be parsed
        Console.WriteLine(ParseText(longText, openTag, closeTag) == ParseTextRegex(longText, openTag, closeTag));

        Stopwatch sw = new Stopwatch();
        int repeat = 10000;

        // Measure method 1
        sw.Restart();
        for (int i = 0; i < repeat; i++)
        {
            ParseText(longText, openTag, closeTag);
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);

        // Measure method 2
        sw.Restart();
        for (int i = 0; i < repeat; i++)
        {
            ParseTextRegex(longText, openTag, closeTag);
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }

    // Generate random text with some tags
    static string GenerateRandomText(string openTag, string closeTag)
    {
        StringBuilder sb = new StringBuilder();
        Random rand = new Random();
        char randChar;
        for (int i = 0; i < 100; i++)
        {
            // Add random chars outside tag
            for (int k = 0; k < rand.Next(30); k++)
            {
                randChar = (char)('a' + rand.Next(26));
                sb.Append(randChar);
            }

            // Add random chars inside tag
            sb.Append(openTag);
            for (int j = 0; j < rand.Next(20); j++)
            {
                randChar = (char)('a' + rand.Next(26));
                sb.Append(randChar);
            }
            sb.Append(closeTag);
        }
        return sb.ToString();
    }
}