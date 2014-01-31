using System;
using System.IO;

class ExtractTextFromXML
{
    static void Main()
    {
        /* Write a program that extracts from given XML file all the text without the tags.
         * Example:
         * <?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest> Games</instrest><interest>C#</instrest><interest> Java</instrest></interests></student>
         */

        string path = @"...\...\someXML.txt"; // manually created xml file

        using (StreamReader input = new StreamReader(path))
        {
            int ch;

            // Read until you reach the end of the document
            while ((ch = input.Read()) != -1) 
            {
                // Inside text
                if (ch == '>')
                {                    
                    string text = String.Empty;

                    // Read until you reach '<' or end of the doc
                    while ((ch = input.Read()) != -1 && ch != '<')
                    {
                        text += (char)ch;
                    }

                    if (!String.IsNullOrWhiteSpace(text)) // Exclude non-text strings such as white-space or empty
                    {
                        Console.WriteLine(text.Trim()); // Also remove leading and trailing white-space
                    }
                }
            }
        }
    }
}
