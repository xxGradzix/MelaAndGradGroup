using Logic.Repositories;
using Data.API;
using Data.API.Entities;

namespace LogicTest.RepositoriesTest
{
    
    public class EventRepositoryTest
    {
        private class FakeEvent : IEvent
        {
            public Guid eventId { get; } = Guid.NewGuid();
            public DateTime timestamp { get; set; } = DateTime.Now;
        }

        private class FakeDataContext : IData
        {
            private readonly List<IEvent> events = new();

            public void AddEvent(IEvent productEvent) => events.Add(productEvent);

            public List<IEvent> GetEvents() => new(events);

            public IUser? GetUser(Guid id) => null;
            public List<IUser> GetUsers() => new();
            public void AddUser(IUser user) { }
            public bool DeleteUser(Guid id) => false;

            public IProduct? getProduct(Guid id) => null;
            public List<IProduct> getProducts() => new();
            public void AddProduct(IProduct item) { }
            public bool DeleteProduct(Guid id) => false;
        }

        [Test]
        public void AddEvent_AddsToDataContext()
        {
            var data = new FakeDataContext();
            var repo = new EventRepository(data);
            var ev = new FakeEvent();

            repo.AddEvent(ev);
            var allEvents = repo.GetAllEvents();

            Assert.AreEqual(1, allEvents.Count);
            Assert.AreEqual(ev.eventId, allEvents[0].eventId);
        }

        [Test]
        public void GetAllEvents_ReturnsAllAdded()
        {
            var data = new FakeDataContext();
            var repo = new EventRepository(data);

            var e1 = new FakeEvent();
            var e2 = new FakeEvent();

            repo.AddEvent(e1);
            repo.AddEvent(e2);

            var result = repo.GetAllEvents();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Exists(e => e.eventId == e1.eventId));
            Assert.IsTrue(result.Exists(e => e.eventId == e2.eventId));
        }
    }
}
