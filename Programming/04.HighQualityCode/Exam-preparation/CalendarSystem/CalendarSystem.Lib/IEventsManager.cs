namespace CalendarSystem.Lib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines methods for adding, deleting and listing events.
    /// </summary>
    public interface IEventsManager
    {
        /// <summary>
        /// Adds an event to the list of events.
        /// </summary>
        /// <param name="ev">The <see cref="CalendarSystem.Lib.Event"> to be added.</param>
        void AddEvent(Event ev);

        /// <summary>
        /// Deletes all events matching the given title in case insensitive manner.
        /// </summary>
        /// <param name="title">The title of the event(s).</param>
        /// <returns>Returns the number of events that were deleted.</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Lists the events starting from the given date.
        /// The number of events will be equal or less (if not enough events are available) 
        /// than the number provided by the'count' parameter.
        /// The listed events are ordered chronologically by date and time
        /// and then by title and location (in ascending order).
        /// </summary>
        /// <param name="fromDate">The date after which the events will be listed.</param>
        /// <param name="count">The number of events to list.</param>
        /// <returns>Returns the list of events found.</returns>
        IEnumerable<Event> ListEvents(DateTime fromDate, int count);
    }
}