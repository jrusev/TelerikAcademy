using System;
using System.IO;


class ReplaceSubstrings
{
    static void Main()
    {
        // Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file.
        // Ensure it will work with large files (e.g. 100 MB).

        string inputPath = @"...\...\input.txt";
        string outputPath = @"...\...\replaced.txt";

        // Build a large file first
        BuildLargeFile(inputPath, 1048576); // 1 MB

        // Replace the substrings and write them to a new file
        using (StreamReader input = new StreamReader(inputPath))
        {
            using (StreamWriter output = new StreamWriter(outputPath))
            {
                string fileLine;
                while ((fileLine = input.ReadLine()) != null)
                {
                    string newLine = fileLine.Replace("start", "finish");
                    output.WriteLine(newLine);
                }
            }
        }

        // Replace the original file with the new file, and create a backup of the original 
        File.Replace(outputPath, inputPath, @"...\...\backup.txt");

        Console.WriteLine("Substrings replaced.");
    }

    // Builds a large file by repeating the word "start"
    private static void BuildLargeFile(string path, int size)
    {
        Console.WriteLine("Building {0:F1} MB file, please wait...", size / (double)1048576);

        using (StreamWriter writer = new StreamWriter(path))
        {
            long fileSize = 0;

            while (fileSize < size)
            {
                writer.WriteLine("start");
                FileInfo file = new FileInfo(path);
                fileSize = file.Length;
            }
        }
    }
}