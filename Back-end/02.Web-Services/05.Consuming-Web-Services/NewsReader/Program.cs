using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;

class Program
{
    // Write a console application, which searches for news articles by given a query string and a count of articles to retrieve.
    // The application should print the Titles and URLs of the articles. For news articles search use the Feedzilla API.
    static void Main()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://api.feedzilla.com/");

        GetArticles("Apple", 10, client);
        Console.ReadLine();
    }

    static async void GetArticles(string query, int count, HttpClient client)
    {
        var response = await client.GetAsync("v1/articles/search.json?q=" + query + "&count=" + count);

        // check response.IsSuccessStatusCode here
        var json = await response.Content.ReadAsStringAsync();

        var jsonObj = JObject.Parse(json);
        var articles = jsonObj["articles"];

        var nl = Environment.NewLine;
        Console.WriteLine(string.Join(nl, articles.Select(a => a["title"] + nl + a["url"] + nl)));
    }
}