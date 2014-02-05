namespace CustomAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class AuthorAttribute : System.Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Author = name;
        }

        public string Author { get; private set; }
    }
}