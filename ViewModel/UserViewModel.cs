using Model.Interfaces;

namespace ViewModel
{
    public class UserViewModel : PropertyChange, IUserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Username
        {
            get => username;
            set { username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set { phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        public UserViewModel(int id, string username, string password, string email, string phoneNumber)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
        public UserViewModel()
        {
            id = 0;
            username = "";
            password = "";
            email = "";
            phoneNumber = "";
        }

    }
}
