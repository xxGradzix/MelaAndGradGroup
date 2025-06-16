using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Data.Events;
using Model.Interfaces;

namespace ViewModel
{
    public class EventListViewModel : PropertyChange
    {
        private IDataModel data;
        private int _eventId;
        private int _nrOfProducts;

        private EventViewModel selectedEvent;
        public ObservableCollection<EventViewModel> Events { get; set; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand LoadCommand { get; }
        public EventListViewModel()
        {
            Events = new ObservableCollection<EventViewModel> { };
            AddCommand = new RelayCommand(() => add());
            DeleteCommand = new RelayCommand(() => delete());
            UpdateCommand = new RelayCommand(() => update());
            LoadCommand = new RelayCommand(() => load());
            data = IDataModel.CreateNewDataModel();
        }

        public EventListViewModel(IDataModel model)
        {
            Events = new ObservableCollection<EventViewModel> { };
            AddCommand = new RelayCommand(() => add());
            DeleteCommand = new RelayCommand(() => delete());
            UpdateCommand = new RelayCommand(() => update());
            LoadCommand = new RelayCommand(() => load());
            data = model;
        }

        public int EventId
        {
            get => _eventId;
            set { _eventId = value; OnPropertyChanged(nameof(EventId)); }
        }

        public int NrOfProducts
        {
            get => _nrOfProducts;
            set { _nrOfProducts = value; OnPropertyChanged(nameof(NrOfProducts)); }
        }


        public EventViewModel SelectedViewModel
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                OnPropertyChanged(nameof(SelectedViewModel));
                if (value != null)
                {
                    _eventId = value.eventId;
                    _nrOfProducts = value.nrOfProducts;
                }
            }
        }

        // private Event _selectedEvent;
        // public Event SelectedEvent
        // {
        //     get => _selectedEvent;
        //     set
        //     {
        //         if (_selectedEvent != value)
        //         {
        //             _selectedEvent = value;
        //             OnPropertyChanged(nameof(SelectedEvent));
        //         }
        //     }
        // }

        public void add()
        {
            Events.Add(new EventViewModel(EventId, NrOfProducts));
            data.AddEvent(EventId, NrOfProducts);
        }

        public void delete()
        {
            for (int i = Events.Count - 1; i >= 0; i--)
            {
                if (Events[i].EventId == EventId)
                {
                    Events.RemoveAt(i);
                    break;
                }
            }
            data.RemoveEvent(EventId);
        }

        public void update()
        {
            delete();
            add();
        }

        public void load()
        {
            Events.Clear();
            foreach (var item in data.GetAllEvent())
            {
                Events.Add(new EventViewModel(EventId = item.eventId, NrOfProducts = item.nrOfProducts));
            }
        }

        // public event PropertyChangedEventHandler PropertyChanged;
        // protected void OnPropertyChanged(string propertyName)
        // {
        //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        // }
    }
}
