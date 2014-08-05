namespace CalendarSystem.Client
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using CalendarSystem.Lib;

    // Performs operations on the eventsManager
    public class CalendarSystemController
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        private readonly IEventsManager eventsManager;

        public CalendarSystemController(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public string DeleteEvents(string[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new InvalidOperationException("Invalid command parameters");
            }

            int eventsRemoved = this.eventsManager.DeleteEventsByTitle(parameters[0]);

            if (eventsRemoved == 0)
            {
                // BUG FIXED: there was a period at the end of "No events found".
                return "No events found";
            }

            return eventsRemoved + " events deleted";
        }

        public string AddEvent(string[] parameters)
        {
            if (parameters.Length != 2 && parameters.Length != 3)
            {
                throw new InvalidOperationException("Invalid command parameters");
            }

            string dateString = parameters[0];
            DateTime date = this.ExtractDate(parameters[0]);

            string title = parameters[1];
            string location = (parameters.Length == 3) ? parameters[2] : null;

            this.eventsManager.AddEvent(new Event(date, title, location));

            return "Event added";
        }

        public string ListEvents(string[] parameters)
        {
            if (parameters.Length != 2)
            {
                throw new InvalidOperationException("Invalid command parameters");
            }

            string dateString = parameters[0];
            DateTime date = this.ExtractDate(dateString);
            var count = int.Parse(parameters[1]);

            var events = this.eventsManager.ListEvents(date, count).ToList();
            var buffer = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var ev in events)
            {
                buffer.AppendLine(ev.ToString());
            }

            return buffer.ToString().Trim();
        }

        private DateTime ExtractDate(string dateString)
        {
            try
            {
                DateTime date = DateTime.ParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture);
                return date;
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid date format" + dateString);
            }
        }
    }
}