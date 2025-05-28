using Presentation.Model;
using Presentation.Model.API;
using Logic.Services;
using Logic.Services.Interfaces;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    internal class MainViewModel : PropertyChange
    {
        private object selectedViewModel;

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

        public MainViewModel()
        {
            ShowProductViewCommand = new RelayCommand(_ => ShowProductView());
            ShowUserViewCommand = new RelayCommand(_ => ShowUserView());
            ShowEventViewCommand = new RelayCommand(_ => ShowEventView());

            ShowProductView();
        }

        private void ShowProductView()
        {
            SelectedViewModel = new ProductListViewModel();
        }

        private void ShowUserView()
        {
            SelectedViewModel = new UserListViewModel();
        }

        private void ShowEventView()
        {
            SelectedViewModel = new EventListViewModel();
        }
    }
}
