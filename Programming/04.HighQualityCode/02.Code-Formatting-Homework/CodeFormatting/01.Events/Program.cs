using System;

public class Program
{
    private static EventHolder events = new EventHolder();

    private static void Main()
    {
        while (ExecuteNextCommand())
        {
        }

        Console.WriteLine(events.Output);
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();
        switch (command[0])
        {
            case 'A':
                AddEvent(command);
                return true;
            case 'D':
                DeleteEvents(command);
                return true;
            case 'L':
                ListEvents(command);
                return true;
            default:
                return false;
        }
    }

    private static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        DateTime date = GetDate(command, "ListEvents");
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);
        events.ListEvents(date, count);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
        events.DeleteEvents(title);
    }

    private static void AddEvent(string command)
    {
        DateTime date;
        string title, location;
        GetParameters(command, "AddEvent", out date, out title, out location);
        events.AddEvent(date, title, location);
    }

    private static void GetParameters(string command, string cmdType, out DateTime date, out string title, out string location)
    {
        date = GetDate(command, cmdType);
        int firstPipeIndex = command.IndexOf('|');
        int lastPipeIndex = command.LastIndexOf('|');
        if (firstPipeIndex == lastPipeIndex)
        {
            title = command.Substring(firstPipeIndex + 1).Trim();
            location = string.Empty;
        }
        else
        {
            title = command.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            location = command.Substring(lastPipeIndex + 1).Trim();
        }
    }

    private static DateTime GetDate(string command, string commandType)
    {
        var date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
        return date;
    }
}