using Data.API.Entities;
using Data.Enums;
using Data.Users;

namespace Data.Factories
{
    public class UserFactory : IUserFactory
    {
        public IUser CreateUser(string name, string surname, string email, string phoneNumber)
        {
            Guid id = Guid.NewGuid();
            string password = string.Empty;
            
            Role role = Role.USER;
            
            return new User(surname, email, password, phoneNumber, role);
        }
    }
}