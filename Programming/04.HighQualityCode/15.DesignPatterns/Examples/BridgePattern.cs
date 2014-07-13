namespace DesignPatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var documents = new List<Manuscript>();
            var formatter = new FancyFormatter();

            var faq = new FAQ(formatter) { Title = "The Bridge Pattern FAQ" };
            faq.Questions.Add("What is it?", "A design pattern");
            faq.Questions.Add("When do we use it?", "When you need to separate an abstraction from an implementation.");
            documents.Add(faq);

            var book = new Book(formatter)
            {
                Title = "Lots of Patterns",
                Author = "John Sonmez",
                Text = "Blah blah blah..."
            };
            documents.Add(book);

            var paper = new TermPaper(formatter)
            {
                Class = "Design Patterns",
                Student = "Joe N00b",
                Text = "Blah blah blah...",
                References = "GOF"
            };
            documents.Add(paper);

            foreach (var doc in documents)
            {
                doc.Print();
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    internal abstract class Manuscript
    {
        protected readonly IFormatter Formatter;

        protected Manuscript(IFormatter formatter)
        {
            this.Formatter = formatter;
        }

        public abstract void Print();
    }

    internal class Book : Manuscript
    {
        public Book(IFormatter formatter)
            : base(formatter)
        {
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public override void Print()
        {
            Console.WriteLine(Formatter.Format("Title", this.Title));
            Console.WriteLine(Formatter.Format("Author", this.Author));
            Console.WriteLine(Formatter.Format("Text", this.Text));
            Console.WriteLine();
        }
    }

    internal class TermPaper : Manuscript
    {
        public TermPaper(IFormatter formatter)
            : base(formatter)
        {
        }

        public string Class { get; set; }

        public string Student { get; set; }

        public string Text { get; set; }

        public string References { get; set; }

        public override void Print()
        {
            Console.WriteLine(Formatter.Format("Class", this.Class));
            Console.WriteLine(Formatter.Format("Student", this.Student));
            Console.WriteLine(Formatter.Format("Text", this.Text));
            Console.WriteLine(Formatter.Format("References", this.References));
            Console.WriteLine();
        }
    }

    internal class FAQ : Manuscript
    {
        public FAQ(IFormatter formatter)
            : base(formatter)
        {
            this.Questions = new Dictionary<string, string>();
        }

        public string Title { get; set; }

        public Dictionary<string, string> Questions { get; set; }

        public override void Print()
        {
            Console.WriteLine(Formatter.Format("Title", this.Title));
            foreach (var question in this.Questions)
            {
                Console.WriteLine(Formatter.Format("   Question", question.Key));
                Console.WriteLine(Formatter.Format("   Answer", question.Value));
            }

            Console.WriteLine();
        }
    }

    internal interface IFormatter
    {
        string Format(string key, string value);
    }

    internal class FancyFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format("-= {0} ----- =- {1}", key, value);
        }
    }

    internal class BackwardsFormatter : IFormatter
    {
        public string Format(string key, string value)
        {
            return string.Format("{0}: {1}", key, new string(value.Reverse().ToArray()));
        }
    }
}
