using Data.API.Entities;
using Data.Enums;

namespace Data.Events
{
    public class Event : IEvent
    {
        public Guid eventId { get; }
        public Guid productId { get; set; }
        
        public ProductEventType eventType { get; set; }
        
        public int quantityChange { get; set; }

        public DateTime timestamp { get; set; }

    }
}