using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoChat.Client;

class MongoChatClient
{
    static void Main()
    {
        var db = new MongoClient(Connections.Default.MongoCloud).GetServer().GetDatabase("mongochat");
        var messages = db.GetCollection<BsonDocument>("Messages");

        Console.Write("Username: ");
        string username = Console.ReadLine();

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                messages.Insert(
                    new BsonDocument { { "Author", username }, { "Text", input }, { "Time", DateTime.Now } });

            var formattedMessages = messages
                .FindAll()
                .Select(m => string.Format("[{0}] {1}: {2}", m["Time"].ToLocalTime(), m["Author"], m["Text"]));

            Console.WriteLine(string.Join(Environment.NewLine, formattedMessages));
        }
    }
}