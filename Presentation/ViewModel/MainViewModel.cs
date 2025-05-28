using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    internal class MainViewModel : PropertyChange
    {
        private PropertyChange _selectedViewModel;

        public PropertyChange SelectedViewModel
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public ICommand UpdateViewCommand { get; }

        public MainViewModel()
        {
            UpdateViewCommand = new RelayCommand(ChangeView);
            SelectedViewModel = new ProductListViewModel();
        }

        private void ChangeView(object? parameter)
        {
            switch (parameter?.ToString())
            {
                case "Products":
                    SelectedViewModel = new ProductListViewModel();
                    break;
                //case "Users":
                //    SelectedViewModel = new UserListViewModel();
                //    break;
                //case "Orders":
                //    SelectedViewModel = new OrderListViewModel();
                //    break;
                //default:
                //    SelectedViewModel = new ProductListViewModel();
                //    break;
            }
        }
    }
}
