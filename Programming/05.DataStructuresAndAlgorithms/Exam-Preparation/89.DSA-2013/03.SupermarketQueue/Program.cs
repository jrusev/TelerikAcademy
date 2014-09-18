using System;
using System.Text;
using Wintellect.PowerCollections;

public class Program
{
    private static readonly BigList<string> queue = new BigList<string>();
    private static readonly Bag<string> names = new Bag<string>();
    private static readonly StringBuilder output = new StringBuilder();

    static void Main()
    {
        string line = Console.ReadLine();
        while (!line.StartsWith("End"))
        {
            var commands = line.Split(' ');
            ExecuteCommand(commands);
            line = Console.ReadLine();
        }

        Console.WriteLine(output.ToString().Trim() + Environment.NewLine + Environment.NewLine);
    }

    static void ExecuteCommand(string[] commands)
    {
        switch (commands[0])
        {
            case "Append": Append(commands); break;
            case "Insert": Insert(commands); break;
            case "Find": Find(commands); break;
            case "Serve": Serve(commands); break;
        }
    }

    static void Append(string[] commands)
    {
        queue.Add(commands[1]);
        names.Add(commands[1]);
        PrintMessage("OK");
    }

    static void Insert(string[] commands)
    {
        var position = int.Parse(commands[1]);
        if (position < 0 || position > queue.Count)
        {
            PrintMessage("Error");
            return;
        }

        queue.Insert(position, commands[2]);
        names.Add(commands[2]);
        PrintMessage("OK");
    }

    static void Find(string[] commands)
    {
        PrintMessage(names.NumberOfCopies(commands[1]));
    }

    static void Serve(string[] commands)
    {
        var count = int.Parse(commands[1]);
        if (count > queue.Count)
        {
            PrintMessage("Error");
            return;
        }

        var servedPeople = queue.GetRange(0, count);
        queue.RemoveRange(0, count);
        names.RemoveMany(servedPeople);

        PrintMessage(string.Join(" ", servedPeople));
    }

    static void PrintMessage(object message)
    {
        output.AppendLine(message.ToString());
    }
}