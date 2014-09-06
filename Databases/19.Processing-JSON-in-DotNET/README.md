## Processing JSON in .NET

Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:

1. The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
* Download the content of the feed programmatically
    * You can use ```WebClient.DownloadFile()```
* Parse the XML from the feed to JSON
* Using LINQ-to-JSON select all the question titles and print them to the console
* Parse the JSON string to POCO
* Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question's page