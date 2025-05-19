using Data.Enums;

namespace Data.Users
{
    internal class Admin : User
    {
        internal Admin(string username, string password, string email, string phoneNumber)
            : base(username, email, password, phoneNumber, Role.ADMIN)
        {
        }
    }
}
