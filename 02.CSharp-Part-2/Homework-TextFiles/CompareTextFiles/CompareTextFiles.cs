using System;
using System.IO;

class CompareTextFiles
{
    static void Main()
    {
        // Write a program that compares two text files line by line
        // and prints the number of lines that are the same and the number of lines that are different.
        // Assume the files have equal number of lines.

        int sameLines = 0;
        int diffLines = 0;
        using (StreamReader input1 = new StreamReader(@"...\...\CompareTextFiles.cs"))
        {
            using (StreamReader input2 = new StreamReader(@"...\...\CompareTextFiles.txt"))
            {
                while (true)
                {
                    string fileLine1 = input1.ReadLine();
                    string fileLine2 = input2.ReadLine();
                    if (fileLine1 == null || fileLine2 == null)
                    {
                        break;
                    }
                    if (fileLine1 == fileLine2) sameLines++;
                    else diffLines++;                 
                }
            }
        }
        Console.WriteLine("Same lines: {0}", sameLines);
        Console.WriteLine("Diff lines: {0}", diffLines);
    }
}