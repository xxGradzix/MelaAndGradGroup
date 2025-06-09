using Data.API.Entities;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    public class EventService : IEventService
    {
        private readonly List<IEvent> events = new();

        public bool AddEvent(IEvent e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            events.Add(e);
            return true;
        }

        public List<IEvent> GetAllEvents()
        {
            return new List<IEvent>(events); 
        }
    }
}
