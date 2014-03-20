using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;

class RemoveWords
{
    static void Main()
    {
        // Write a program that removes from a text file all words listed in another text file.
        // Handle all possible exceptions in your methods.

        Console.WriteLine("This program removes C# key words from a file.");

        string fileWords = @"...\...\Words-to-remove.txt"; // the file that contains the list of words
        string fileToFix = @"...\...\RemoveWords.cs"; // the file where those words must be removed
        string fileNew = @"...\...\Words-removed.txt"; // the new file with the removed words

        try
        {
            // Get all lines in the file and store them in a list of strings
            List<string> wordsList = ReadLines(fileWords);

            Console.WriteLine("The following words will be deleted from this source file:");
            wordsList.Sort();
            foreach (var item in wordsList) Console.WriteLine(item);

            // Build a regex pattern from the words
            string words = String.Join("|", wordsList); // Joins the words in a special string
            string regex = @"\b(" + words + @")\b"; // ... and inserts the string into the regex expression

            // Get all lines in the file and store them in a list of strings
            List<string> fileLinesToFix = ReadLines(fileToFix);

            // Delete the text that matches the pattern (remove the words)
            DeleteText(fileLinesToFix, regex);

            Console.WriteLine("=============================================");
            Console.WriteLine("This is the source file without the keywords:");
            foreach (var line in fileLinesToFix) Console.WriteLine(line);

            // Write the clean text to a new file
            WriteLines(fileLinesToFix, fileNew);
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found!");
        }

        catch (SecurityException)
        {
            Console.WriteLine("Security error is detected!");
        }

        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static List<string> ReadLines(string path)
    {
        List<string> fileLines = new List<string>();

        using (StreamReader input = new StreamReader(path))
        {
            string lineString;
            while ((lineString = input.ReadLine()) != null)
            {
                fileLines.Add(lineString);
            }
        }

        return fileLines;
    }

    // Delete the text that matches the pattern
    static void DeleteText(List<string> lines, string pattern)
    {
        for (int i = 0; i < lines.Count; i++)
        {
            // Replaces all strings that match the pattern with an empty string 
            string newLine = Regex.Replace(lines[i], pattern, String.Empty);
            lines[i] = newLine;
        }
    }

    static void WriteLines(List<string> lines, string path)
    {
        using (StreamWriter output = new StreamWriter(path))
        {
            foreach (string line in lines)
            {
                output.WriteLine(line);
            }
        }
    }
}