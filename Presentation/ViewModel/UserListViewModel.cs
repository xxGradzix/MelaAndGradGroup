using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Presentation.Model;
using Presentation.Model.API;

namespace Presentation.ViewModel
{
    internal class UserListViewModel : PropertyChange
    {
        private readonly IModel _model;
        private UserViewModel? _selectedUser;

        public ObservableCollection<UserViewModel> Users { get; } = new();

        public UserViewModel? SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanModifyUser)); // <- kluczowe!
            }
        }

        // Właściwość dla bindingu XAML
        public bool CanModifyUser => SelectedUser != null;

        public ICommand AddUserCommand { get; }
        public ICommand RemoveUserCommand { get; }
        public ICommand RefreshUsersCommand { get; }

        // Konstruktor dla design-time lub testów
        public UserListViewModel()
        {
            Users.Add(new UserViewModel
            {
                Id = Guid.NewGuid(),
                Username = "SampleUser",
                Password = "password",
                Email = "user@example.com",
                PhoneNumber = "123456789",
                Role = Model.API.Enums.RoleModel.USER
            });

            AddUserCommand = new RelayCommand(_ => { });
            RemoveUserCommand = new RelayCommand(_ => { }, _ => SelectedUser != null);
            RefreshUsersCommand = new RelayCommand(_ => { });
        }

        // Konstruktor główny
        public UserListViewModel(IModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));

            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser, _ => SelectedUser != null);
            RefreshUsersCommand = new RelayCommand(_ => LoadUsers());

            LoadUsers();
        }

        private void LoadUsers()
        {
            Users.Clear();
            foreach (var user in _model.GetAllUsers())
            {
                Users.Add(UserViewModel.FromModel(user));
            }

            if (Users.Count > 0)
            {
                SelectedUser = Users[0];
            }
        }

        private void AddUser(object? parameter)
        {
            var newUser = new UserViewModel
            {
                Id = Guid.NewGuid(),
                Username = "NewUser",
                Password = "password",
                Email = "email@example.com",
                PhoneNumber = "000000000",
                Role = Model.API.Enums.RoleModel.USER
            };

            _model.RegisterUser(newUser.Username, newUser.Password, newUser.Email, newUser.PhoneNumber);
            LoadUsers();
        }

        private void RemoveUser(object? parameter)
        {
            if (SelectedUser == null) return;

            _model.RemoveUser(SelectedUser.Id);
            LoadUsers();
        }
    }
}
