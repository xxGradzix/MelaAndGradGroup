using Data.API.Entities;

namespace LogicTest.testEntities
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

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
