using System;
using MongoDB.Driver;
using MongoChat.Models;

class MongoChatClient
{
    static void Main()
    {
        string mongoLab = "mongodb://telerik:chat@ds035300.mongolab.com:35300/mongochat";
        string local = "mongodb://127.0.0.1";

        string connString = mongoLab;
        string dbName = "mongochat";

        var db = new MongoClient(connString).GetServer().GetDatabase(dbName);
        var messages = db.GetCollection<Message>("Messages");

        Console.Write("Username: ");
        string username = Console.ReadLine();

        while (true)
        {
            Console.Write("> ");
            messages.Insert(new Message(username, Console.ReadLine(), DateTime.Now));
            Console.WriteLine(string.Join(Environment.NewLine, messages.FindAll()));
        }
    }
}
