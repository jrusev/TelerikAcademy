using System;
using System.Collections.Generic;
using System.Linq;

using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

using Logger.Models;
using ExtensionsMethods;

class MongoCRUD
{
    const string DatabaseHost = "mongodb://127.0.0.1";
    const string DatabaseName = "Logger";

    static void Main()
    {
        var db = GetDatabase(DatabaseName, DatabaseHost);
        db.Drop();

        var logs = db.GetCollection<Log>("Logs");

        Create(logs);

        Read(logs);

        Modify(logs);

        Delete(logs);

        WorkWithBson();
    }

    private static void Create(MongoCollection<Log> logs)
    {
        logs.InsertBatch(CreateSampleLogs(10));
        logs.Insert(new Log("Some logs added", DateTime.Now));
        Console.WriteLine("CREATE");
        logs.FindAll().Print();
    }

    private static void Read(MongoCollection<Log> logs)
    {
        Console.WriteLine("READ");

        //// Native
        //var findLogsQuery = Query.And(Query.EQ("LogType.Type", "bug"), Query.GT("LogDate", DateTime.Now.AddDays(-7)));
        //logs.Find(findLogsQuery).Print();

        //// Linq
        //var findBugsQuery = Query<Log>.Where(log => log.LogType.Type == "bug" && log.LogDate > DateTime.Now.AddDays(-7));
        //logs.Find(findBugsQuery).Print();

        // LinqToMongoDB
        var newBugs = logs.AsQueryable<Log>().Where(log => log.LogType.Type == "bug" && log.LogDate > DateTime.Now.AddDays(-7));
        newBugs.Print();
    }

    private static void Modify(MongoCollection<Log> logs)
    {
        Console.WriteLine("UPDATE");

        var query = Query.EQ("LogType.State", "pending");
        var update = Update.Set("Text", "Changed to 'closed'").Set("LogType.State", "closed");
        logs.Update(query, update, UpdateFlags.Multi);

        logs.Find(Query.EQ("Text", "Changed to 'closed'")).Print();
    }

    private static void Delete(MongoCollection<Log> logs)
    {
        var findOldLogsQuery = Query.And(Query.LT("LogDate", DateTime.Now.AddDays(-1)));
        logs.Remove(findOldLogsQuery);
        Console.WriteLine("DELETE");
        logs.FindAll().Print();
    }

    static IEnumerable<Log> CreateSampleLogs(int count)
    {
        var date = DateTime.Now;
        var logs = new List<Log>(count);

        for (var i = 0; i < count; i++)
        {
            var logState = (i % 2 == 0) ? "closed" : "pending";
            var logType = (i % 3 == 0) ? "bug" : (i % 3 == 1) ? "feature-request" : "ticket";
            var text = string.Format("Log  #{0}", i);
            var log = new Log(text, date);
            log.LogType = new LogType() { State = logState, Type = logType };
            logs.Add(log);
            date = date.AddDays(-1);
        }

        return logs;
    }

    // http://stackoverflow.com/a/18069949
    private static void WorkWithBson()
    {
        //build some test data
        BsonArray dataFields = new BsonArray { new BsonDocument { 
		     { "ID" , ObjectId.GenerateNewId()}, { "NAME", "ID"}, {"TYPE", "Text"} } };
        BsonDocument nested = new BsonDocument {
            { "name", "John Doe" },
            { "fields", dataFields },
            { "address", new BsonDocument {
                    { "street", "123 Main St." },
                    { "city", "Madison" },
                    { "state", "WI" },
                    { "zip", 53711}
                }
		     }
		 };
        // grab the address from the document,
        // subdocs as a BsonDocument
        var address = nested["address"].AsBsonDocument;
        Console.WriteLine(address["city"].AsString);
        // or, jump straight to the value ...
        Console.WriteLine(nested["address"]["city"].AsString);
        // loop through the fields array
        var allFields = nested["fields"].AsBsonArray;
        foreach (var fields in allFields)
        {
            // grab a few of the fields:
            Console.WriteLine("Name: {0}, Type: {1}",
                fields["NAME"].AsString, fields["TYPE"].AsString);
        }

        // Madison
        // Madison
        // Name: ID, Type: Text
    }

    static MongoDatabase GetDatabase(string name, string fromHost)
    {
        return new MongoClient(fromHost).GetServer().GetDatabase(name);
        //var mongoClient = new MongoClient(fromHost);
        //var server = mongoClient.GetServer();
        //return server.GetDatabase(name);
    }
}
