using Presentation.Model;
using Presentation.Model.API;
using Logic.Services;
using Logic.Services.Interfaces;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class MainViewModel : PropertyChange
    {
        private object selectedViewModel;

        private readonly IModel model;
        
        public object SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand ShowProductViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }
        public ICommand ShowEventViewCommand { get; }

        public MainViewModel(IModel model)
        {
            this.model = model;

            // Initialize the selected view model to ProductListViewModel by default
            SelectedViewModel = new ProductListViewModel(model);

            // Initialize commands
            ShowProductViewCommand = new RelayCommand(_ => ShowProductView());
            ShowUserViewCommand = new RelayCommand(_ => ShowUserView());
            ShowEventViewCommand = new RelayCommand(_ => ShowEventView());
        }   

        private void ShowProductView()
        {
            SelectedViewModel = new ProductListViewModel(model);
        }

        private void ShowUserView()
        {
            SelectedViewModel = new UserListViewModel(model);
        }

        private void ShowEventView()
        {
            SelectedViewModel = new EventListViewModel(model);
        }
    }
}
