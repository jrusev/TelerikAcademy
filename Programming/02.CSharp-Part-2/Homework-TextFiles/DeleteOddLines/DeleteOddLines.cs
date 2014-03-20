using System;
using System.Collections.Generic;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        // Write a program that deletes from given text file all odd lines. The result should be in the same file.

        string inputPath = @"...\...\DeleteOddLines.cs";
        string outputPath = @"...\...\EvenLines.txt";

        List<string> evenLines = ReadEvenLines(inputPath);
        WriteLines(evenLines, outputPath);
    }

    static List<string> ReadEvenLines(string path)
    {
        List<string> evenLines = new List<string>();

        int currentLine = 1;

        using (StreamReader input = new StreamReader(path))
        {
            string lineString;
            while ((lineString = input.ReadLine()) != null)
            {
                if (currentLine % 2 == 0) evenLines.Add(lineString);
                currentLine++;
            }
        }

        return evenLines;
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