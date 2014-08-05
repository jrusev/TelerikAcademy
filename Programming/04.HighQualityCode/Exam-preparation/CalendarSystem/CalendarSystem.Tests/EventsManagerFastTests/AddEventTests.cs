using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem.Lib;
using System.Linq;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class AddEventTests
    {
        private DateTime minDate = DateTime.Parse("2000-01-01");

        [TestMethod]
        public void AddedEventIsCorrectlyReturned()
        {
            EventsManagerFast manager = new EventsManagerFast();
            var ev = new Event(minDate, "test", null);
            manager.AddEvent(ev);

            var actual = manager.ListEvents(minDate, 1).First();

            Assert.AreEqual<Event>(ev, actual);
        }

        [TestMethod]
        public void AddedEventWitLocationIsCorrectlyReturned()
        {
            EventsManagerFast manager = new EventsManagerFast();
            var ev = new Event(minDate, "test", "bar");
            manager.AddEvent(ev);

            var actual = manager.ListEvents(minDate, 1).First();

            Assert.AreEqual<Event>(ev, actual);
        }

        [TestMethod]
        public void DuplicateEventsAreAccepted()
        {
            EventsManagerFast manager = new EventsManagerFast();
            var ev = new Event(minDate, "test", null);
            manager.AddEvent(ev);
            manager.AddEvent(ev);

            var actual = manager.ListEvents(minDate, 2).Count();

            Assert.AreEqual(2, actual);
        }
    }
}
