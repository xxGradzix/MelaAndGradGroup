using Data.Events;
using Data.States;

namespace Data.Events
{
    internal class DatabaseEvent: Event
    {
        public DatabaseEvent(int eventId, State state): base(eventId, state)
        {
        }
    }
}
