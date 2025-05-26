using Data.Repositories;
using Data.API;
using Data.API.Entities;
using Data.dataContextImpl.database;
using Data.Events;
using Microsoft.EntityFrameworkCore;

namespace LogicTest.RepositoriesTest
{
    
    public class EventRepositoryTest
    {
        
        private class FakeEvent : Event
        {
        }
        
        private DbContextOptions<AppDbContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        private EventRepository GetRepo()
        {
            var options = GetInMemoryOptions();
            var context = new AppDbContext(options);
            return new EventRepository(context);
        }
        
        [Test]
        public void AddEvent_AddsToDataContext()
        {
            var data = GetRepo();
                                
            var ev = new FakeEvent();

            data.Save(ev);
            var allEvents = data.FindAll();

            Assert.AreEqual(1, allEvents.Count);
            Assert.AreEqual(ev.eventId, allEvents[0].eventId);
        }

        [Test]
        public void GetAllEvents_ReturnsAllAdded()
        {
            var data = GetRepo();

            var e1 = new FakeEvent();
            var e2 = new FakeEvent();

            data.Save(e1);
            data.Save(e2);

            var result = data.FindAll();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Exists(e => e.eventId == e1.eventId));
            Assert.IsTrue(result.Exists(e => e.eventId == e2.eventId));
        }
    }
}
