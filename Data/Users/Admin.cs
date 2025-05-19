using Data.Enums;

namespace Data.Users
{
    internal class Admin : User
    {
        internal Admin(string username, string email, string phoneNumber)
            : base(username, email, phoneNumber, Role.ADMIN)
        {
        }
    }
}
