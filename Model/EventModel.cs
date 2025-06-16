using Data.States;
using Model.Interfaces;

namespace Data.Events
{
    internal class EventModel : IEventModel
    {
        public EventModel(int eventId, int nrOfProducts)
        {
            this.eventId = eventId;
            this.nrOfProducts = nrOfProducts;
        }

        public int eventId { get; set; }
        public int nrOfProducts { get; set; }
    }
}