using Presentation.ViewModel;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel : PropertyChange
    {
        private PropertyChange selectedVM;
        public ICommand ShowCatalogViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }
        public ICommand ShowEventViewCommand { get; }
        public ICommand ShowStateViewCommand { get; }


        public PropertyChange SelectedViewModel
        {
            get
            {
                return selectedVM;
            }

            set
            {
                selectedVM = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public MainViewModel()
        {
            SelectedViewModel = new CatalogListViewModel();
            ShowCatalogViewCommand = new RelayCommand(() => ShowProductView());
            ShowUserViewCommand = new RelayCommand(() => ShowUserView());
            ShowEventViewCommand = new RelayCommand(() => ShowEventView());
            ShowStateViewCommand = new RelayCommand(() => ShowStateView());
        }   

        private void ShowProductView()
        {
            SelectedViewModel = new CatalogListViewModel();
        }

        private void ShowUserView()
        {
            SelectedViewModel = new UserListViewModel();
        }

        private void ShowEventView()
        {
            SelectedViewModel = new EventListViewModel();
        }  
        private void ShowStateView()
        {
            SelectedViewModel = new StateListViewModel();
        }
    }
}
