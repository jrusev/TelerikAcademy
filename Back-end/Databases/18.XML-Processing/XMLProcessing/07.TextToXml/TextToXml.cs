using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Linq;

// In a text file we are given the name, address and phone number of given person (each at a single line).
// Write a program, which creates new XML document, which contains these data in structured XML format.
class TextToXml
{
    private static string inputFile = "../../people.txt";
    private static string outputFile = "../../people.xml";

    static void Main()
    {
        using (var reader = new StreamReader(inputFile))
        {
            string line = reader.ReadLine();

            if (line == null)
            {
                Console.WriteLine("The text file is empty");
                return;
            }

            using (var writer = new XmlTextWriter(outputFile, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("People");

                while (line != null)
                {
                    var tokens = line.Split(';').Select(t => t.Trim()).ToArray();

                    WritePerson(writer, name: tokens[0], address: tokens[1], phone: tokens[2]);
                    line = reader.ReadLine();
                }

                writer.WriteEndDocument();

                Console.WriteLine("XML file saved to {0}", outputFile);
            }
        }
    }

    public static void WritePerson(XmlWriter writer, string name, string address, string phone)
    {
        writer.WriteStartElement("person");
        {
            writer.WriteElementString("name", name);
            writer.WriteElementString("address", address);
            writer.WriteElementString("phone", phone);
        }
        writer.WriteEndElement();
    }
}
