namespace CustomAttributes
{
    using System;
    using System.Reflection;

    // Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods
    // and holds a version in the format major.minor (e.g. 2.11).
    // Apply the version attribute to a sample class and display its version at runtime.
    [Author("Unknown")]
    [Version(2, 11)]
    public class Program
    {
        [Version(2, 1)]
        public static void Main(string[] args)
        {
            Type type = typeof(Program);

            // Get all class attributes
            object[] classAttributes = type.GetCustomAttributes(false);
            foreach (Attribute attr in classAttributes)
            {
                if (attr is AuthorAttribute)
                {
                    Console.WriteLine("Class author: {0}", (attr as AuthorAttribute).Author);
                }

                if (attr is VersionAttribute)
                {
                    Console.WriteLine("Class version: {0}", (attr as VersionAttribute).Version);
                }
            }

            // Get all public methods of the class
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                // Get all attributes of the current method
                object[] methodAttributes = method.GetCustomAttributes(false);

                foreach (Attribute attr in methodAttributes)
                {
                    if (attr is VersionAttribute)
                    {
                        Console.WriteLine("\"{0}\" method version: {1}", method.Name, (attr as VersionAttribute).Version);
                    }
                }
            }
        }
    }
}