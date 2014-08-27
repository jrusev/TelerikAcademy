using System;
using System.IO;

// Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively
// and to display all files matching the mask *.exe. Use the class System.IO.Directory.
public class DirectoryTraversal
{
    private static void Main()
    {
        ////TraverseDir(new DirectoryInfo("../../.."), 0);

        string path = "C:\\WINDOWS";
        string pattern = "*.exe";
        SearchDir(new DirectoryInfo(path), pattern);
    }

    // Displays all files in a folder (and all its subfolders) matching a given search pattern
    private static void SearchDir(DirectoryInfo dir, string mask)
    {
        try
        {
            SearchFileInFolder(dir, mask);            
            foreach (DirectoryInfo child in dir.EnumerateDirectories())
            {
                SearchDir(child, mask);
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Access to this folder denied...");
        }
    }

    // Displays all files in a specific folder that match a given search pattern
    private static void SearchFileInFolder(DirectoryInfo dir, string mask)
    {
        foreach (var file in dir.EnumerateFiles(mask))
        {
            Console.WriteLine(file.FullName.Substring(dir.FullName.Length + 1));
        }
    }

    // Prints given directory and all its subdirectories
    private static void TraverseDir(DirectoryInfo dir, int indent)
    {
        try
        {
            Console.WriteLine(new string(' ', indent) + dir.Name);

            DirectoryInfo[] children = dir.GetDirectories();
            foreach (DirectoryInfo child in children)
            {
                TraverseDir(child, indent + 2);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Access to this folder denied...");
        }
    }
}
