using System;
using System.Collections.Generic;
using System.IO;

// A text file phones.txt holds information about people, their town and phone number:
//      Kevin Clark         | Virginia beach    | 1-454-345-2345
//      Skiller             | San Antonio       | 1-566-533-2789
//      Kevin Clark Jones   | Portland          | 1-432-556-6533
//      Linda Johnson       | San Antonio       | 1-123-345-2456
//      Kevin               | Phoenix           | 1-564-254-4352
//      Kevin Garcia        | Virginia Beach    | 1-445-456-6732
//      Kevin               | Phoenix           | 1-134-654-7424
// Duplicates can occur in people names, towns and phone numbers.
// Write a program to read the phones file and execute a sequence of commands given in the file commands.txt.
//      find(name) – display all matching records by given name (first, middle, last or nickname)
//      find(name, town) – display all matching records by given name and town
public class Program
{
    public static void Main()
    {
        var phones = ReadPhones("../../phones.txt");
        var phonebook = new Phonebook(phones);

        var commands = ReadCommands("../../commands.txt");
        ProcessCommands(commands, phonebook);
    }

    // Executes each command and searches the phonebook
    private static void ProcessCommands(IEnumerable<string> commands, Phonebook phonebook)
    {
        foreach (var command in commands)
        {
            Console.WriteLine("$ " + command);
            var args = command.Substring(5, command.Length - 6);
            var searchTerms = args.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var entries = phonebook.Find(searchTerms);
                Console.WriteLine(string.Join("\n", entries));
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Not found: {0}", args);
            }

            Console.WriteLine("----------------------------------------------");
        }
    }

    // Reads a specified file and returns a list of phonebook commands
    private static IEnumerable<string> ReadCommands(string path)
    {
        using (var input = new StreamReader(path))
        {
            string fileLine;
            var commands = new List<string>();
            while ((fileLine = input.ReadLine()) != null)
            {
                commands.Add(fileLine);
            }

            return commands;
        }
    }

    // Reads a specified file and returns a list of phonebook entries
    private static IEnumerable<PhonebookEntry> ReadPhones(string path)
    {
        using (var input = new StreamReader(path))
        {
            var phonebookEntries = new List<PhonebookEntry>();
            string fileLine;
            while ((fileLine = input.ReadLine()) != null)
            {
                var tokens = fileLine.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                phonebookEntries.Add(
                    new PhonebookEntry
                    {
                        Name = tokens[0],
                        Town = tokens[1],
                        Phone = tokens[2]
                    });
            }

            return phonebookEntries;
        }
    }
}
