using Data.API.Entities;

namespace LogicLayerTest
{
    internal class TestUser : IUser
    {
        public TestUser(int userId, string username, string password, string email, string phoneNumber)
        {
            this.id = userId;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
    }
}
