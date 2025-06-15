using Data.API.Entities;
using Data.States;

namespace Data.Events
{
    internal class Event : IEvent
    {
        public int eventId {  get; set; }
        public IState state {  get; set; }

        public Event(int eventId, IState state)
        {
            this.eventId = eventId;
            this.state = state;
        }
    }
}