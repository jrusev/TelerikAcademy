using System;
using MongoDB.Driver;
using MongoChat.Models;

class MongoChatClient
{
    const string MongoCloud = "mongodb://telerik:chat@ds035300.mongolab.com:35300/mongochat";
    const string MongoLocal = "mongodb://localhost";

    static void Main()
    {
        string connString = MongoCloud;

        var db = new MongoClient(connString).GetServer().GetDatabase("mongochat");
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
