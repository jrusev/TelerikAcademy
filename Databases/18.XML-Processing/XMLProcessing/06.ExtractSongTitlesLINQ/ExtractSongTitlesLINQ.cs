using System;
using System.Linq;
using System.Xml.Linq;

// Write a program to extracts all song titles from catalog.xml, using XDocument and LINQ query.
class ExtractSongTitlesLINQ
{
    static void Main()
    {
        var doc = XDocument.Load("../../../catalogue.xml");
        Console.WriteLine(string.Join(", ", doc.Descendants("song").Select(s => s.Value)));
    }
}
