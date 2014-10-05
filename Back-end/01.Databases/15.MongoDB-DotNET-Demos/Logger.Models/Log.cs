namespace Logger.Models
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Log
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime LogDate { get; set; }

        public LogType LogType { get; set; }

        public Log(string text, DateTime logDate)
        {
            this.Text = text;
            this.LogDate = logDate;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} {2}", this.LogDate, this.Text, this.LogType);
        }
    }
}
