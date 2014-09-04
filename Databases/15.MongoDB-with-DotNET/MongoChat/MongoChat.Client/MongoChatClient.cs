using System;
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
            messages.Insert(new BsonDocument { { "Author", username }, { "Text", Console.ReadLine() }, { "Time", DateTime.Now } });
            Console.WriteLine(string.Join(Environment.NewLine, messages.FindAll()));
        }
    }
}
