using System;
using System.Linq;
using System.Xml.Linq;

// Extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. Use LINQ query.
class ExtractOldAlbumPricesLINQ
{
    private static string filePath = "../../../catalogue.xml";

    static void Main()
    {
        var doc = XElement.Load(filePath);
        var albums = from album in doc.Elements("album")
                     where int.Parse(album.Element("year").Value) < (DateTime.Now.Year - 5)
                     select new
                     {
                         title = album.Element("name").Value,
                         year = album.Element("year").Value,
                         price = album.Element("price").Value
                     };

        foreach (var album in albums)
        {
            Console.WriteLine("{0} ({2}) -> {1}", album.title, album.price, album.year);
        }
    }
}
