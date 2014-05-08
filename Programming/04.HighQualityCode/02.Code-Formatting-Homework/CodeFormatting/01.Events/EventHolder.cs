using System;
using System.Text;
using Wintellect.PowerCollections;

public class EventHolder
{
    private MultiDictionary<string, Event> dictByTitle;
    private OrderedBag<Event> orderedByDate;

    public EventHolder()
    {
        this.dictByTitle = new MultiDictionary<string, Event>(true);
        this.orderedByDate = new OrderedBag<Event>();
        this.Output = new StringBuilder();
    }

    public StringBuilder Output { get; private set; }

    public void AddEvent(DateTime date, string title, string location)
    {
        Event newEvent = new Event(date, title, location);
        this.dictByTitle.Add(title.ToLower(), newEvent);
        this.orderedByDate.Add(newEvent);
        Messages.EventAdded(this.Output);
    }

    public void DeleteEvents(string titleToDelete)
    {
        string title = titleToDelete.ToLower();
        int removed = 0;
        foreach (var eventToRemove in this.dictByTitle[title])
        {
            removed++;
            this.orderedByDate.Remove(eventToRemove);
        }

        this.dictByTitle.Remove(title);
        Messages.EventDeleted(removed, this.Output);
    }

    public void ListEvents(DateTime date, int count)
    {
        var eventsToShow = this.orderedByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
        int showed = 0;
        foreach (var eventToShow in eventsToShow)
        {
            if (showed == count)
            {
                break;
            }

            Messages.PrintEvent(eventToShow, this.Output);
            showed++;
        }

        if (showed == 0)
        {
            Messages.NoEventsFound(this.Output);
        }
    }
}
