using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem.Lib;
using System.Collections.Generic;

namespace CalendarSystem.Tests.EventsManagerFastTests
{
    [TestClass]
    public class ListEventsTests
    {
        private DateTime minDate = DateTime.Parse("2000-01-01");

        [TestMethod]
        public void EventsAreListedSorted()
        {
            EventsManagerFast manager = new EventsManagerFast();

            // Unsorted events
            var events = new List<Event>
            {
                new Event(DateTime.Parse("2010-01-01"), "testB", "foo"),
                new Event(minDate, "test", null),
                new Event(minDate, "test", "bar"),
                new Event(minDate, "test", "foo"),
                new Event(minDate, "testB", "foo")                
            };

            // Events are added unsorted
            foreach (var ev in events)
            {
                manager.AddEvent(ev);
            }

            var managerEvents = manager.ListEvents(minDate, 5).ToList();

            // Assert 5 are added
            Assert.AreEqual(5, managerEvents.Count);

            events.Sort();
            CollectionAssert.AreEqual(events, managerEvents);
        }
    }
}
