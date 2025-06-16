using Data.API.Entities;
using Data.States;

namespace Data.Events
{
    public class Event : IEvent
    {
        public int Id {  get; set; }
        public State state {  get; set; }

        public Event() { } 
        
        
        public Event(int Id, State state)
        {
            this.Id = Id;
            this.state = state;
        }
    }
}