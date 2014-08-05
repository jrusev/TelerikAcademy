using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem.Lib;

namespace CalendarSystem.Tests.EventsManagerFastTests
{
    [TestClass]
    public class DeleteEventsByTitleTests
    {
        private DateTime minDate = DateTime.Parse("2000-01-01");

        [TestMethod]
        public void DeleteSingleEvent()
        {
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(new Event(minDate, "test", null));

            int numDeleted = manager.DeleteEventsByTitle("test");

            Assert.AreEqual(1, numDeleted);

            var eventCount = manager.ListEvents(minDate, 1).Count();

            Assert.AreEqual(0, eventCount);
        }

        [TestMethod]
        public void DeleteMultipleEvents()
        {
            EventsManagerFast manager = new EventsManagerFast();

            manager.AddEvent(new Event(minDate, "test", null));
            manager.AddEvent(new Event(minDate, "test", "bar"));
            manager.AddEvent(new Event(minDate, "other", "bar"));

            int numDeleted = manager.DeleteEventsByTitle("test");

            Assert.AreEqual(2, numDeleted);

            var eventCount = manager.ListEvents(minDate, 3).Count();

            // assert "other" is not deleted
            Assert.AreEqual(1, eventCount);
        }
    }
}
