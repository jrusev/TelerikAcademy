using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

// Create a XML file representing catalogue. The catalogue should contain albums of different artists.
// For each album you should define: name, artist, year, producer, price and a list of songs.
class CreateXMLFile
{
    private static CultureInfo culture = CultureInfo.GetCultureInfo("en-Us");

    private static Encoding encoding = Encoding.GetEncoding("windows-1251");

    private static string filePath = "../../../catalogue.xml";

    static void Main()
    {
        using (var writer = new XmlTextWriter(filePath, encoding))
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement("catalogue");
            writer.WriteAttributeString("name", "Awesome Mix Vol. 1");

            WriteAlbum(writer, "Hooked on a Feeling", "Blue Swede", 1968, "Scepter Records", 20);

            WriteAlbum(writer, "Record World", "Raspberries", 1972, "Capitol Records", 18.50m,
                new List<string>() { "Don't Want to Say Goodbye", "Go All the Way", "I Wanna Be with You" });

            WriteAlbum(writer, "Starting Over", "Raspberries", 1974, "Capitol", 17.50m);

            WriteAlbum(writer, "Wovoka", "Redbone", 1974, "Lolly Vegas", 11,
                new List<string>() { "Come and Get Your Love", "When You Got Trouble" });

            WriteAlbum(writer, "The 5th Dimension", "Blue Swede", 1974, "Warner Bros.", 9.99m);

            writer.WriteEndDocument();
        }

        Console.WriteLine("Document saved to {0}", filePath);
    }

    private static void WriteAlbum(XmlWriter writer, string name, string artist, short year, string producer,
        decimal price, List<string> songs = null)
    {
        writer.WriteStartElement("album");
        writer.WriteElementString("name", name);
        writer.WriteElementString("artist", artist);
        writer.WriteElementString("year", year.ToString());
        writer.WriteElementString("producer", producer);
        writer.WriteElementString("price", string.Format(culture, "{0:C}", price));
        if ((songs != null) && (songs.Count > 0))
        {
            writer.WriteStartElement("songs");
            foreach (var song in songs)
            {
                writer.WriteElementString("song", song);
            }

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
    }
}
