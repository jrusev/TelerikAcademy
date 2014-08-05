namespace CalendarSystem.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Event> eventsByTitle;
        private readonly OrderedMultiDictionary<DateTime, Event> eventsByDate;

        public EventsManagerFast()
        {
            this.eventsByTitle = new MultiDictionary<string, Event>(true);
            this.eventsByDate = new OrderedMultiDictionary<DateTime, Event>(true);
        }

        public void AddEvent(Event ev)
        {
            if (ev == null)
            {
                throw new ArgumentNullException("event");
            }

            string eventTitleLowerCase = ev.Title.ToLowerInvariant();
            this.eventsByTitle.Add(eventTitleLowerCase, ev);
            this.eventsByDate.Add(ev.Date, ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException("title");
            }

            string titleLowerCase = title.ToLowerInvariant();

            // IMPROVED PERFORMANCE:
            //   1) Event titles are already stored in lowercase as keys
            //   2) Searching a dictionary by key is fast (takes constant time)
            var eventsToDelete = this.eventsByTitle[titleLowerCase];
            int eventCount = eventsToDelete.Count;

            foreach (var ev in eventsToDelete)
            {
                this.eventsByDate.Remove(ev.Date, ev);
            }

            this.eventsByTitle.Remove(titleLowerCase);

            return eventCount;
        }

        public IEnumerable<Event> ListEvents(DateTime dateFrom, int count)
        {
            // IMPROVED PERFORMANCE:
            // Using OrderedDictionary keeps the collection sorted by Date
            // and then by Event which is IComparable
            var events = this.eventsByDate.RangeFrom(dateFrom, true).Values.Take(count);
            return events;
        }
    }
}