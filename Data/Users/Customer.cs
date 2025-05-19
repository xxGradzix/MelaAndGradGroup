
using Data.Enums;

namespace Data.Users
{
    internal class Customer : User
    {

        internal Customer(string username, string email, string password, string phoneNumber)
            : base(username, email, password, phoneNumber, Role.USER)
        {
        }
    }
}
