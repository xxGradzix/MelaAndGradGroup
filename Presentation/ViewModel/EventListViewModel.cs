using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Presentation.Model.API;

namespace Presentation.ViewModel
{
    internal class EventListViewModel : PropertyChange
    {
        private readonly IModel _model;
        private EventViewModel? _selectedEvent;

        public ObservableCollection<EventViewModel> Events { get; } = new();

        public EventViewModel? SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddEventCommand { get; }
        public ICommand RemoveEventCommand { get; }

     

        // Konstruktor produkcyjny
        public EventListViewModel(IModel model)
        {
            _model = model;
            AddEventCommand = new RelayCommand(_ => AddEvent());
            RemoveEventCommand = new RelayCommand(_ => RemoveEvent(), _ => SelectedEvent != null);

            LoadEvents();
        }

        private void LoadEvents()
        {
            Events.Clear();
            foreach (var e in _model.GetAllEvents())
            {
                Events.Add(EventViewModel.FromModel(e));
            }
        }

        private void AddEvent()
        {
            var newEvent = new EventViewModel
            {
                EventId = Guid.NewGuid(),
                Timestamp = DateTime.Now
            };

            _model.AddEvent(newEvent.EventId, newEvent.Timestamp);
            LoadEvents();
        }

        private void RemoveEvent()
        {
            if (SelectedEvent == null) return;

            //_model.RemoveEvent(SelectedEvent.EventId);
            LoadEvents();
        }
    }
}
