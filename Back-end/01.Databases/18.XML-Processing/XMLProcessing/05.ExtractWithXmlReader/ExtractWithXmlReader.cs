using System;
using System.Xml;

// Write a program, which using XmlReader extracts all song titles from catalog.xml.
class ExtractWithXmlReader
{
    static void Main()
    {
        using (var reader = XmlReader.Create("../../../catalogue.xml"))
            while (reader.Read())
                if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "song")
                    Console.WriteLine(reader.ReadInnerXml());
    }
}
