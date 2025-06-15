using Logic.Services.Interfaces;

namespace Logic.Services  
{
    internal class EventService : IEventService
    {
        public EventService(int i, int s)
        {
            id = i;
            stateId = s;
        }
        public int id { get; set; }
        public int stateId { get; set; }
    }
}
