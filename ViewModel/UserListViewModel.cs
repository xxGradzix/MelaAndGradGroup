using System.Collections.ObjectModel;
using System.Windows.Input;
using Data.API.Entities;
using Model.Interfaces;
using ViewModel;

namespace Presentation.ViewModel
{
    internal class UserListViewModel : PropertyChange
    {
        private IDataModel data;
        private int _id;
        private string _username;
        private string _password;
        private string _email;
        private string _phoneNumber;

        private UserViewModel selectedUser;
        public ObservableCollection<UserViewModel> Users { get; set; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand LoadCommand { get; }
        public UserListViewModel()
        {
            Users = new ObservableCollection<UserViewModel> { };
            AddCommand = new RelayCommand(() => add());
            DeleteCommand = new RelayCommand(() => delete());
            UpdateCommand = new RelayCommand(() => update());
            LoadCommand = new RelayCommand(() => load());
            data = IDataModel.CreateNewDataModel();
        }

        public UserListViewModel(IDataModel model)
        {
            Users = new ObservableCollection<UserViewModel> { };
            AddCommand = new RelayCommand(() => add());
            DeleteCommand = new RelayCommand(() => delete());
            UpdateCommand = new RelayCommand(() => update());
            LoadCommand = new RelayCommand(() => load());
            data = model;
        }

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        public UserViewModel SelectedViewModel
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedViewModel));
                if (value != null)
                {
                    Id = value.Id;
                    Username = value.Username;
                    Password = value.Password;
                    Email = value.Email;
                    PhoneNumber = value.PhoneNumber;
                }
            }
        }


        public void add()
        {
            Users.Add(new UserViewModel(Id, Name, Password, Email, PhoneNumber));
            data.AddUser(Id, Name, Password, Email, PhoneNumber);
        }

        public void delete()
        {
            for (int i = Users.Count - 1; i >= 0; i--)
            {
                if (Users[i].Id == Id)
                {
                    Users.RemoveAt(i);
                    break;
                }
            }
            data.RemoveUser(Id);
        }

        public void update()
        {
            delete();
            add();
        }

        public void load()
        {
            Users.Clear();
            foreach (var user in data.GetAllUsers())
            {
                Users.Add(new UserViewModel(Id = user.id, Username = user.username, Password = user.password, Email = user.email, PhoneNumber = user.phoneNumber));
            }
        }
    }
}
