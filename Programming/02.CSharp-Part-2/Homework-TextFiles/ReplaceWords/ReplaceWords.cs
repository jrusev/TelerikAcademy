using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWords
{
    static void Main()
    {
        // Write a program that replaces all occurrences of the word "start" with the word "finish" in a text file.
        // Replace only whole words (not substrings).

        string inputPath = @"...\...\input.txt";
        string outputPath = @"...\...\replaced.txt";

        // Build a large file first
        BuildLargeFile(inputPath, 524288); // 512 KB

        // Replace the substrings and write them to a new file
        using (StreamReader input = new StreamReader(inputPath))
        {
            using (StreamWriter output = new StreamWriter(outputPath))
            {
                string fileLine;
                while ((fileLine = input.ReadLine()) != null)
                {
                    string newLine = Regex.Replace(fileLine, @"\bstart\b", "finish");
                    output.WriteLine(newLine);
                }
            }
        }

        // Replace the original file with the new file, and create a backup of the original 
        File.Replace(outputPath, inputPath, @"...\...\backup.txt");

        Console.WriteLine("Substrings replaced.");
    }

    // Builds a large file by repeating the word "start"
    private static void BuildLargeFile(string path, int sizeBytes)
    {
        Console.WriteLine("Building {0:F1} KB file, please wait...", sizeBytes / (double)1024);

        using (StreamWriter writer = new StreamWriter(path))
        {
            long fileSize = 0;

            while (fileSize < sizeBytes)
            {
                writer.WriteLine("start");
                FileInfo file = new FileInfo(path);
                fileSize = file.Length;
            }
        }
    }
}