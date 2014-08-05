namespace CalendarSystem.Client
{
    using System;
    using System.IO;
    using CalendarSystem.Lib;

    public class CalendarSystemDemo
    {
        private const string TestIn001 = @"AddEvent 2012-01-21T20:00:00 | party Viki | home
AddEvent 2012-03-26T09:00:00 | C# exam
AddEvent 2012-03-26T09:00:00 | C# exam
AddEvent 2012-03-26T08:00:00 | C# exam
AddEvent 2012-03-07T22:30:00 | party | Vitosha
ListEvents 2012-03-07T08:00:00 | 3
DeleteEvents c# exam
DeleteEvents My granny's bushes
ListEvents 2013-11-27T08:30:25 | 25
AddEvent 2012-03-07T22:30:00 | party | Club XXX
ListEvents 2012-01-07T20:00:00 | 10
AddEvent 2012-03-07T22:30:00 | Party | Club XXX
ListEvents 2012-03-07T22:30:00 | 3
End
";

        internal static void Main()
        {
            // Sets the Console to read from string
            ////Console.SetIn(new StringReader(TestIn001));

            IEventsManager eventsManager = new EventsManagerFast();
            var calendarSystemController = new CalendarSystemController(eventsManager);

            var commandFactory = new CommandFactory(calendarSystemController);
            var commandParser = new CommandParser(commandFactory);

            var commandExecutor = new CommandExecutor();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End" || input == null)
                {
                    break;
                }

                ICommand cmd = commandParser.Parse(input);
                var result = commandExecutor.ExecuteCommand(cmd);
                Console.WriteLine(result);
            }
        }
    }
}