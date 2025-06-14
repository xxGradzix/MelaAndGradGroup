
namespace Data.Events
{
    internal class Event : IEvent
    {
        public Event(int eventId, State state)
        {
            this.eventId = eventId;
            this.state = state;
        }
    }
}