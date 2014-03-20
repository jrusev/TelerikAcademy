using System;
using System.IO;

class PrintFileOddLines
{
    static void Main()
    {
        // Write a program that reads a text file and prints on the console its odd lines.

        using (StreamReader sr = new StreamReader(@"...\...\PrintFileOddLines.cs"))
        {
            string fileLine;
            int line = 1; // the first line
            while ((fileLine = sr.ReadLine()) != null)
            {
                if (line % 2 != 0)
                {
                    Console.WriteLine(fileLine);
                }
                line++;
            }
        }
    }
}