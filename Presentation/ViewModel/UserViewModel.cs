using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Presentation.Model;
using Presentation.Model.API;
using Presentation.Model.API.Enums;

namespace Presentation.ViewModel
{
    internal class UserViewModel : PropertyChange
    {
        private Guid _id;
        private string _username;
        private string _password;
        private string _email;
        private string _phoneNumber;
        private RoleModel _role;

        public Guid Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        public RoleModel Role
        {
            get => _role;
            set { _role = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static UserViewModel FromModel(IUserModelData model)
        {
            return new UserViewModel
            {
                Id = model.id,
                Username = model.username,
                Password = model.password,
                Email = model.email,
                PhoneNumber = model.phoneNumber,
                Role = model.role
            };
        }

        public IUserModelData ToModel()
        {
            return new UserModelData(Id, Username, Password, Email, PhoneNumber, Role);
        }
    }
}
