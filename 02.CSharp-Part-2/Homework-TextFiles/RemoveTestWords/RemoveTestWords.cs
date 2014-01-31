using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class RemoveTestWords
{
    static void Main()
    {
        // Write a program that deletes from a text file all words that start with the prefix "test".
        // Words contain only the symbols 0...9, a...z, A…Z, _.

        string inputPath = @"...\...\RemoveTestWords.cs";
        string outputPath = @"...\...\TestWordsRemoved.txt";

        // The regex pattern used to find the words with prefix test
        string pattern = @"\btest\w*\b";

        // Get all lines in the file and store them in a list of strings
        List<string> fileLines = ReadLines(inputPath);

        // Delete the text that matches the pattern
        DeleteText(fileLines, pattern);

        // Write the clean text to a file
        WriteLines(fileLines, outputPath);
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