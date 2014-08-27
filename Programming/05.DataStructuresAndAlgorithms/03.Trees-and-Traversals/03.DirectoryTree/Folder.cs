using System;
using System.Collections.Generic;
using System.Linq;

// Class Folder containing a list of files and subfolders
public class Folder
{
    private IList<File> files;
    private IList<Folder> childFolders;

    public Folder(string name)
    {
        this.Name = name;
        this.files = new List<File>();
        this.childFolders = new List<Folder>();       
    }

    public string Name { get; private set; }

    public long Size
    {
        get
        {
            return this.Sizebytes();
        }
    }

    public override string ToString()
    {
        return this.Name;
    }

    public void AddFile(File file)
    {
        this.files.Add(file);
    }

    public void AddFolder(Folder folder)
    {
        this.childFolders.Add(folder);
    }

    // Prints all files and folders in this folder (not recursive)
    public void Print()
    {
        Console.WriteLine(string.Join("\n", this.childFolders));
        Console.WriteLine("." + string.Join("\n.", this.files));        
    }

    // Prints all files and folders in this folder (recursive)
    public void PrintRecursive()
    {       
        this.Print(string.Empty, true);
    }

    // Prints the nodes recursively
    private void Print(string prefix, bool isTail)
    {
        Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + this.Name);
        for (int i = 0; i < this.childFolders.Count - 1; i++)
        {
            this.childFolders[i].Print(prefix + (isTail ? "    " : "│   "), false);
        }

        if (this.childFolders.Count >= 1)
        {
            this.childFolders[this.childFolders.Count - 1].Print(prefix + (isTail ? "    " : "│   "), true);
        }
    }

    private long Sizebytes()
    {
        long currentSize = this.files.Sum(f => f.SizeBytes);
        foreach (var childFolder in this.childFolders)
        {
            currentSize += childFolder.Sizebytes();
        }

        return currentSize;
    }
}
