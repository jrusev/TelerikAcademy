using System;
using System.IO;

class ConcatTwoFiles
{
    static void Main()
    {
        // Write a program that concatenates two text files into another text file.

        string fileText1;
        string fileText2;

        using (StreamReader sr = new StreamReader(@"...\...\ConcatTwoFiles.cs"))
        {
            fileText1 = sr.ReadToEnd(); // For small files
        }

        using (StreamReader sr = new StreamReader(@"...\...\ConcatTwoFiles.cs"))
        {
            fileText2 = sr.ReadToEnd(); // For small files
        }

        using (StreamWriter sw = new StreamWriter(@"...\...\TwoFiles.txt"))
        {
            sw.Write(fileText1 + fileText2);
        }

        using (StreamReader sr = new StreamReader(@"...\...\TwoFiles.txt"))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
}