using System;
using System.Linq;
using System.Xml.Linq;

// Write a program to extracts all song titles from catalog.xml, using XDocument and LINQ query.
class ExtractSongTitlesLINQ
{
    static void Main()
    {
        var doc = XDocument.Load("../../../catalogue.xml");
        
        // Descendants() finds children at any level, i.e. children, grand-children, etc...
        // Elements() finds only those elements that are direct descendents, i.e. immediate children.
        Console.WriteLine(string.Join(", ", doc.Descendants("song").Select(s => s.Value)));
    }
}
