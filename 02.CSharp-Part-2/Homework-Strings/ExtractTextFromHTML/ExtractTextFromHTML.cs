using System;
using System.Text;

class ExtractTextFromHTML
{
    static void Main()
    {
        // Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.

        string html =
            @"
            <html>
              <head><title>News</title></head>
              <body><p><a href=""http://academy.telerik.com"">Telerik
                Academy</a>aims to provide free real-world practical
                training for young people who want to turn into
                skillful .NET software engineers.</p></body>
            </html>";

        StringBuilder sb = new StringBuilder();
        bool insideTag = false;

        foreach (var ch in html)
        {
            if (insideTag)
            {
                if (ch == '>')
                {
                    insideTag = false;
                    sb.Append(' ');
                }
            }
            else
            {
                if (ch == '<')
                {
                    insideTag = true;
                }
                else
                {
                    sb.Append(ch);
                }
            }
        }

        Console.WriteLine(sb.ToString());
    }
}