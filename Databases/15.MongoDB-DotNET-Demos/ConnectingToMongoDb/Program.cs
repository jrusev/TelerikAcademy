using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensionsMethods;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ConnectingToMongoDb
{
    class Program
    {

        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "Logger";

        class Log
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            public string Text { get; set; }

            public DateTime LogDate { get; set; }

            public Log(string text, DateTime logDate)
            {
                //this.Id = ObjectId.GenerateNewId().ToString();
                this.Text = text;
                this.LogDate = logDate;
            }

            public override string ToString()
            {
                return string.Format("[{0}] {1}", this.LogDate, this.Text);
            }
        }

        static MongoDatabase GetDatabase(string name, string fromHost)
        {
            return new MongoClient(fromHost).GetServer().GetDatabase(name);
            //var mongoClient = new MongoClient(fromHost);
            //var server = mongoClient.GetServer();
            //return server.GetDatabase(name);
        }

        static void Main()
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);

            var logs = db.GetCollection<Log>("Logs");

            //db.Drop();

            logs.Insert(new Log("Something important happened2", DateTime.Now));

            Console.WriteLine(DateTime.Now.ToUniversalTime().AddSeconds(-5));
            var update = Update.Set("Text", "Changed Text at " + DateTime.Now.ToUniversalTime());
            var query = Query.And(
                Query.LT("LogDate", DateTime.Now.ToUniversalTime().AddSeconds(-5))
                );
            logs.Update(query, update);

            logs.FindAll().Print();
        }
    }
}
