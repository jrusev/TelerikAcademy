using System;

class Dictionary
{
    static void Main()
    {
        // A dictionary is stored as a sequence of text lines containing words and their explanations.
        // Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
        //      .NET – platform for applications from Microsoft
        //      CLR – managed execution environment for .NET
        //      namespace – hierarchical organization of classes

        string[] words = { ".NET", "CLR", "namespace" };
        string[] explanation =
        {
            "platform for applications from Microsoft",
            "managed execution environment for .NET",
            "hierarchical organization of classes" 
        };

        while (true)
        {
            Console.Write("Please enter a word: ");
            string query = Console.ReadLine();

            int index = Array.IndexOf(words, query);

            if (index != -1)
            {
                Console.WriteLine(explanation[index]);
            }
            else
            {
                Console.WriteLine("The word is not in the dictionary.");
            }
        }
    }
}