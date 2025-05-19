using Data.Enums;

namespace Data.Users
{
    internal class Customer : User
    {

        internal Customer(string username, string email, string phoneNumber)
            : base(username, email, phoneNumber, Role.USER)
        {
        }
    }
}
