
using Data.API.Entities;

namespace Data.Users
{
    internal class User : IUser
    {
        public User(int id, string username, string password, string email, string phoneNumber)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
    }
}