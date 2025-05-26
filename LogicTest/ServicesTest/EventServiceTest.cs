using Logic.Services;
using Data.API.Entities;


namespace LogicTest.ServicesTest
{
    public class EventServiceTest
    {
        private class FakeEvent : IEvent
        {
            public Guid eventId { get; } = Guid.NewGuid();
            public DateTime timestamp { get; set; } = DateTime.Now;
        }

        [Test]
        public void AddEvent_ShouldAddEvent()
        {
            var service = new EventService();
            var e = new FakeEvent();

            var result = service.AddEvent(e);
            var allEvents = service.GetAllEvents();

            Assert.IsTrue(result);
            Assert.AreEqual(1, allEvents.Count);
            Assert.AreEqual(e.eventId, allEvents[0].eventId);
        }

        [Test]
        public void AddEvent_NullEvent_Throws()
        {
            var service = new EventService();
            Assert.Throws<ArgumentNullException>(() => service.AddEvent(null!));
        }

        [Test]
        public void GetAllEvents_ShouldReturnCopy()
        {
            var service = new EventService();
            var e = new FakeEvent();
            service.AddEvent(e);

            var events1 = service.GetAllEvents();
            var events2 = service.GetAllEvents();

            Assert.AreNotSame(events1, events2);
            Assert.AreEqual(events1.Count, events2.Count);
        }

        [Test]
        public void GetAllEvents_InitiallyEmpty()
        {
            var service = new EventService();
            var result = service.GetAllEvents();

            Assert.AreEqual(0, result.Count);
        }
    }
}
