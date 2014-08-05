namespace CalendarSystem.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventsManager : IEventsManager
    {
        private readonly List<Event> eventList = new List<Event>();

        public void AddEvent(Event ev)
        {
            this.eventList.Add(ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            var searchTitle = title.ToLowerInvariant();

            // BOTTLENECK FOUND: this is a slow operation:
            //   1) Event titles are converted to lowercase every time
            //   2) Searching in a list is slow (the entire collection needs to be iterated)
            // See EventsManagerFast for faster implementation. 
            int eventsRemoved = this.eventList.RemoveAll(e => e.Title.ToLowerInvariant() == searchTitle);
            return eventsRemoved;
        }

        public IEnumerable<Event> ListEvents(DateTime dateFrom, int count)
        {
            // BOTTLENECK FOUND: this is also a slow operation,
            // because events need to be sorted every time.
            // EventsManagerFast uses an OrderedDictionary which keeps the collection sorted
            return (from e in this.eventList
                    where e.Date >= dateFrom
                    orderby e.Date, e.Title, e.Location
                    select e).Take(count);
        }
    }
}