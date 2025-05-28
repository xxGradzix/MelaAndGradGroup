using System;
using Presentation.Model.API;

namespace Presentation.ViewModel
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }
        public DateTime Timestamp { get; set; }

        public static EventViewModel FromModel(IEventModelData model)
        {
            return new EventViewModel
            {
                EventId = model.eventId,
                Timestamp = model.timestamp
            };
        }
    }
}
