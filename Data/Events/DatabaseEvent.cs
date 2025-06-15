using Data.API.Entities;
using Data.Events;
using Data.States;

namespace Data.Events
{
    internal class DatabaseEvent: Event
    {
        public DatabaseEvent(int eventId, IState state): base(eventId, state)
        {
        }
    }
}
