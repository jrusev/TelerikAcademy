using System;
using System.Collections.Generic;
using System.IO;

class SortStringsFromFile
{
    static void Main()
    {
        // Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
        //              Example:
        //      Unsorted  ->    Sorted:
        //      Ivan			George
        //      Peter			Ivan
        //      Maria			Maria
        //      George			Peter

        List<string> strings = ReadList(@"...\...\UnsortedList.txt");

        Console.WriteLine("Unsorted:");
        PrintList(strings);

        strings.Sort();

        Console.WriteLine("Sorted:");
        PrintList(strings);

        SaveList(strings, @"...\...\SortedList.txt");
    }

    static void PrintList(List<string> strings)
    {
        foreach (var item in strings) Console.WriteLine(item);
        Console.WriteLine();
    }

    static List<string> ReadList(string path)
    {
        List<string> strings = new List<string>();

        using (StreamReader input = new StreamReader(path))
        {
            string fileLine;

            while ((fileLine = input.ReadLine()) != null)
            {
                strings.Add(fileLine);
            }
            return strings;
        }
    }

    static void SaveList(List<string> strings, string path)
    {
        using (StreamWriter output = new StreamWriter(path))
        {
            foreach (var item in strings)
            {
                output.WriteLine(item);
            }
        }
    }
}
