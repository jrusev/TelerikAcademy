using System;
using System.Text;
using System.Xml;

// Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml,
// in which stores in appropriate way the names of all albums and their authors.
class XmlToXml
{
    private static string inputFile = "../../../catalogue.xml";
    private static string outputFile = "../../albums.xml";

    static void Main()
    {
        using (var reader = XmlReader.Create(inputFile))
        {
            using (var writer = new XmlTextWriter(outputFile, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                bool openAlbum = false;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "album")
                        {
                            if (openAlbum)
                            {
                                writer.WriteEndElement();
                            }

                            openAlbum = true;
                            writer.WriteStartElement("album");
                        }
                        else if (reader.Name == "name")
                        {
                            writer.WriteElementString("name", reader.ReadElementString());
                        }
                        else if (reader.Name == "artist")
                        {
                            writer.WriteElementString("artist", reader.ReadElementString());
                        }
                    }
                }

                writer.WriteEndDocument();
                Console.WriteLine("XML file saved to {0}", outputFile);
            }
        }
    }
}
