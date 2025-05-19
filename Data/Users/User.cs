
using Data.API.Entities;
using Data.Enums;

namespace Data.Users
{

    internal abstract class User : IUser
    {
        public Guid id { get; private set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public Role role { get; set; }

        internal User(string username, string email, string password, string phoneNumber, Role role)
        {
            id = Guid.NewGuid();
            this.username = username;
            this.email = email;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.role = role;
        }
    }
}