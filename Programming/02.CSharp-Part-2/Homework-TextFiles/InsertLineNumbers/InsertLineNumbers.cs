using System;
using System.IO;

class InsertLineNumbers
{
    static void Main()
    {
        // Write a program that reads a text file and inserts line numbers in front of each of its lines.
        // The result should be written to another text file.

        using (StreamReader input = new StreamReader(@"...\...\InsertLineNumbers.cs"))
        {
            using (StreamWriter output = new StreamWriter(@"...\...\WithLineNumbers.txt"))
            {
                int line = 1; // The first line
                string fileLine;
                while ((fileLine = input.ReadLine()) != null)
                {
                    string newLine = String.Format("{0}. {1}", line, fileLine);
                    output.WriteLine(newLine);
                    Console.WriteLine(newLine);
                    line++;
                }
            }
        }
    }
}