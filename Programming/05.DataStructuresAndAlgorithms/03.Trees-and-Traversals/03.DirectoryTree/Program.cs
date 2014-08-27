using System;
using System.IO;

// Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders }
// and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS.
// Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly.
// Use recursive DFS traversal.
public class Program
{
    private static void Main()
    {
        // Let's work with the project folder
        string path = "../../";
        var folder = new Folder(".");

        Console.WriteLine("Please wait, while the tree is being populated...");
        FillFolder(path, folder);

        Console.WriteLine(new DirectoryInfo(path).FullName);

        // Print all folders in the root of the tree (recursive)        
        folder.PrintRecursive();

        // Print all files and folders in the root of the tree (not recursive)
        Console.WriteLine("------------------------------");
        folder.Print();

        // Print the size of the folder (including all subfolders)
        Console.WriteLine("Folder size is {0:0,0} KB", folder.Size / 1024);
    }

    // Adds all files and folders from 'source' to the root folder recursively
    private static Folder FillFolder(string path, Folder root)
    {
        try
        {
            var source = new DirectoryInfo(path);

            foreach (var file in source.EnumerateFiles())
            {
                root.AddFile(new File(file.Name, file.Length));
            }

            foreach (DirectoryInfo dir in source.EnumerateDirectories())
            {
                root.AddFolder(FillFolder(dir.FullName, new Folder(dir.Name)));                
            }            
        }
        catch (System.Exception)
        { 
        }

        return root;
    }
}
