using Model.Interfaces;

namespace ViewModel
{
    public class EventViewModel : PropertyChange, IEventModel
    {
        public int eventId { get; set; }
        public int nrOfProducts { get; set; }
        public int EventId
        {
            get => eventId;
            set { eventId = value; OnPropertyChanged(nameof(EventId)); }
        }
        public int NrOfBooks
        {
            get => nrOfProducts;
            set { nrOfProducts = value; OnPropertyChanged(nameof(nrOfProducts)); }
        }
        public EventViewModel()
        {
            EventId = 0;
            nrOfProducts = 0;
        }
        public EventViewModel(int e, int s)
        {
            EventId = e;
            nrOfProducts = s;
        }
    }
}
