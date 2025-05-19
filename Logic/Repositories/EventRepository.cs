
using Data.API;
using Data.API.Entities;
using Logic.Repositories.Interfaces;

namespace Logic.Repositories
{
    internal class EventRepository : IEventRepository
    {
        private readonly IData context;

        public EventRepository(IData context)
        {
            this.context = context;
        }

        public void AddEvent(IEvent eventBase)
        {
            context.AddEvent(eventBase);
        }

        public List<IEvent> GetAllEvents()
        {
            return context.GetEvents();
        }
    }
}
