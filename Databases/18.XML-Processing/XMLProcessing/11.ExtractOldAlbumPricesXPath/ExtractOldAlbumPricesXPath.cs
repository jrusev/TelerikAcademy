using System;
using System.Xml;

// Extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. Use XPath query.
class ExtractOldAlbumPricesXPath
{
    private static string filePath = "../../../catalogue.xml";

    static void Main()
    {
        var doc = new XmlDocument();
        doc.Load(filePath);

        string XPathQuery = string.Format("/catalogue/album[year<{0}]", DateTime.Now.Year - 5);
        XmlNodeList albums = doc.SelectNodes(XPathQuery);
        foreach (XmlNode album in albums)
        {
            Console.WriteLine(
                "'{0}' album costs {1} and is published in {2}",
                album["name"].InnerText,
                album["price"].InnerText,
                album["year"].InnerText);
        }
    }
}
