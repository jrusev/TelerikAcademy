namespace MongoChat.Models
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

        public Message(string author, string text, DateTime logDate)
        {
            this.Author = author;
            this.Text = text;
            this.Time = logDate;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}: {2}", this.Time, this.Author, this.Text);
        }
    }
}
