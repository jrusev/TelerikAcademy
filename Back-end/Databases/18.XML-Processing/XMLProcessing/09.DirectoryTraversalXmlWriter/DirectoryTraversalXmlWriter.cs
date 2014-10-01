using System;
using System.IO;
using System.Text;
using System.Xml;

// Write a program to traverse given directory and write to a XML file its contents
// together with all subdirectories and files. Use tags <file> and <dir> with appropriate attributes.
// For the generation of the XML document use the class XmlWriter.
class DirectoryTraversalXmlWriter
{
    private static string rootDirectory = "../../..";
    private static string outputFile = "../../directories.xml";

    static void Main()
    {
        using (XmlTextWriter writer = new XmlTextWriter(outputFile, Encoding.UTF8))
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement("directories");

            TraverseDirectory(writer, rootDirectory);

            writer.WriteEndDocument();
            Console.WriteLine("XML file saved to {0}", outputFile);
        }
    }

    private static void TraverseDirectory(XmlWriter writer, string path)
    {
        writer.WriteStartElement("dir");
        writer.WriteAttributeString("name", FormatPath(path));

        foreach (var directory in Directory.EnumerateDirectories(path))
            TraverseDirectory(writer, directory);

        foreach (var file in Directory.EnumerateFiles(path))
            writer.WriteElementString("file", FormatPath(file));

        writer.WriteEndElement();
    }

    private static string FormatPath(string path)
    {
        return path.Substring(path.LastIndexOf('\\') + 1);
    }
}
