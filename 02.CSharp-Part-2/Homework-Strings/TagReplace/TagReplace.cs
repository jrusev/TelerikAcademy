using System;

class TagReplace
{
    static void Main()
    {
        // Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a>
        // with corresponding tags [URL=…]…/URL].
        // Sample HTML fragment:
        //      <p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
        // Result:
        //      <p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

        string html = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

        Console.WriteLine(html);

        html = html.Replace(@"<a href=""", "[URL=");
        html = html.Replace(@""">", "]");
        html = html.Replace(@"</a>", "[/URL]");

        Console.WriteLine(html);
    }
}