using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

// Write program that extracts all different artists which are found in the catalog.xml.
// For each author you should print the number of albums in the catalogue. Use the DOM parser and a hash-table.
class ExtractWithDOMParser
{
    private static string filePath = "../../../catalogue.xml";

    static void Main()
    {
        XmlDocument document = new XmlDocument();
        document.Load(filePath);

        XmlNode rootNode = document.DocumentElement;

        var byArtist = new Dictionary<string, int>();

        foreach (XmlNode child in rootNode.ChildNodes)
        {
            string artistName = child["artist"].InnerText;
            int count;
            byArtist[artistName] = byArtist.TryGetValue(artistName, out count) ? count + 1 : 1;
        }

        foreach (var key in byArtist.Keys)
        {
            Console.WriteLine("{0} album(s) by {1}", byArtist[key], key);
        }
    }
}
