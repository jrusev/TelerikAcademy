using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;


// Implement the previous task using XPath.
class ExtractWithXPath
{
    private static string filePath = "../../../catalogue.xml";

    static void Main()
    {
        XmlDocument document = new XmlDocument();
        document.Load(filePath);

        string XPathQuery = "catalogue/album/artist";

        XmlNodeList artistNames = document.SelectNodes(XPathQuery);

        // By applying OfType<TResult> to a collection that implements IEnumerable,
        // you gain the ability to query the collection by using the standard query operators.
        var result = artistNames.OfType<XmlElement>().GroupBy(e => e.InnerText).ToDictionary(gr => gr.Key, gr => gr.Count());

        Console.WriteLine(string.Join(", ", result));
    }
}
