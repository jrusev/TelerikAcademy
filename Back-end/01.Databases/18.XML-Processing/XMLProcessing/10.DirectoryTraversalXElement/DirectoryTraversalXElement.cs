using System;
using System.IO;
using System.Xml.Linq;

// Write a program to traverse given directory and write to a XML file its contents
// together with all subdirectories and files. Use tags <file> and <dir> with appropriate attributes.
// For the generation of the XML document use XDocument, XElement and XAttribute.
class DirectoryTraversalXElement
{
    private static string rootDirectory = "../../..";
    private static string outputFile = "../../directories.xml";

    static void Main()
    {
        var rootXML = new XElement("directories");
        TraverseDirectory(rootXML, rootDirectory);

        var document = new XDocument(rootXML);
        document.Save(outputFile);
        Console.WriteLine("XML file saved to {0}", outputFile);
    }

    private static void TraverseDirectory(XElement parentXML, string path)
    {
        var directoryXml = new XElement("dir", new XAttribute("name", FormatPath(path)));
        parentXML.Add(directoryXml);

        foreach (var directory in Directory.EnumerateDirectories(path))
            TraverseDirectory(directoryXml, directory);

        foreach (var file in Directory.EnumerateFiles(path))
            directoryXml.Add(new XElement("file", FormatPath(file)));
    }

    private static string FormatPath(string path)
    {
        return path.Substring(path.LastIndexOf('\\') + 1);
    }
}
