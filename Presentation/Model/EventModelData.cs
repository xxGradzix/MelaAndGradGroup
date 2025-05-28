using System;
using Presentation.Model.API;

namespace Presentation.Model
{
    internal class EventModelData : IEventModelData
    {
        public Guid eventId { get; set; }
        public DateTime timestamp { get; set; }

        public EventModelData(Guid eventId, DateTime timestamp)
        {
            this.eventId = eventId;
            this.timestamp = timestamp;
        }
    }
}