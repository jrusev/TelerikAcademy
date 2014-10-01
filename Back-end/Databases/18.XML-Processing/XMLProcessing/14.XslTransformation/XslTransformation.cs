using System;
using System.Xml.Xsl;

// Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.
class XslTransformation
{
    private static string inputFile = "../../../catalogue.xml";
    private static string outputFile = "../../../catalogue.html";
    private static string stylesheet = "../../../catalogue.xsl";

    static void Main()
    {
        var xslt = new XslCompiledTransform();
        xslt.Load(stylesheet);
        xslt.Transform(inputFile, outputFile);

        Console.WriteLine("HTML file saved to {0}", outputFile);
    }
}
