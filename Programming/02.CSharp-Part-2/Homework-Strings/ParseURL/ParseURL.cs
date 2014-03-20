using System;

class ParseURL
{
    static void Main()
    {
        // Write a program that parses an URL address given in the format:
        //      [protocol]://[server]/[resource]
        // and extracts from it the [protocol], [server] and [resource] elements.
        // For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
        //      [protocol] = "http"
        //      [server] = "www.devbg.org"
        //      [resource] = "/forum/index.php"

        string url = "http://www.devbg.org/forum/index.php";

        int index1 = url.IndexOf("://");
        string protocol = url.Substring(0, index1);
        Console.WriteLine("[protocol] = \"" + protocol + "\"");

        int index2 = url.IndexOf("/", index1 + 3);
        string server = url.Substring(index1 + 3, index2 - (index1 + 3));
        Console.WriteLine("[server] = \"" + server + "\"");

        string resource = url.Substring(index2);
        Console.WriteLine("[resource] = \"" + resource + "\"");
    }
}