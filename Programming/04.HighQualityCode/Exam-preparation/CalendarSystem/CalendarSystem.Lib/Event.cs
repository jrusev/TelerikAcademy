namespace CalendarSystem.Lib
{
    using System;

    public class Event : IComparable<Event>
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; private set; }

        public string Title { get; private set; }

        public string Location { get; private set; }

        public override string ToString()
        {
            // BUG FIXED: date format was not in the correct form
            string form = "{0:" + Event.DateTimeFormat + "} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(Event other)
        {
            int result = DateTime.Compare(this.Date, other.Date);

            // BOTTLENECK FOUND: no need to foreach the title (removed)!
            if (result == 0)
            {
                result = string.Compare(this.Title, other.Title, StringComparison.InvariantCulture);
            }

            if (result == 0)
            {
                result = string.Compare(this.Location, other.Location, StringComparison.InvariantCulture);
            }

            return result;
        }
    }
}