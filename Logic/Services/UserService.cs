using System.Runtime.CompilerServices;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    internal class UserService : IUserService
    {
        public UserService(int id, string username, string password, string email, string phoneNumber)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
