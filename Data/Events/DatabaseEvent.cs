using Data;
using Data.Events;

namespace Data.Events
{
    internal class DatabaseEvent: Event
    {
        public DatabaseEvent(int eventId, State state): base(eventId, state)
        {
        }
    }
}
