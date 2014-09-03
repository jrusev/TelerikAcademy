using System;
using System.Linq;
using ExtensionsMethods;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace CrudOperations
{
    class Program
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "Logger";

        static void Main()
        {
            var database = GetDatabase(DatabaseName, DatabaseHost);

            var logsCollection = database.GetCollection<Log>("Logs");

            Log[] logsToInsert =
            {
                new Log("Bug Logged", DateTime.Now.AddHours(-1)),
                new Log("Bug Fixed", DateTime.Now)
            };

            logsCollection.InsertBatch(logsToInsert);

            logsCollection.FindAll().Print();
        }

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
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }
    }
}
