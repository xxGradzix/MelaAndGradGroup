using Logic.Repositories;
using Logic.Repositories.Interfaces;
using Data.API.Entities;
using Data.Enums;


namespace LogicTest.RepositoriesTest
{
    public class UserRepositoryTest
    {
        private class FakeUser : IUser
        {
            public Guid id { get; set; }
            public string username { get; set; } = "";
            public string password { get; set; } = "";
            public string email { get; set; } = "";
            public string phoneNumber { get; set; } = "";
            public Role role { get; set; } = Role.USER;
        }

        [Test]
        public void AddUser_ShouldStoreUser()
        {
            IUserRepository repo = new UserRepository();
            var user = new FakeUser { id = Guid.NewGuid(), email = "example @email.com" };

            repo.AddUser(user);
            var result = repo.GetUser(user.id);

            Assert.IsNotNull(result);
            Assert.AreEqual(user.id, result!.id);
        }

        [Test]
        public void GetUser_NotFound_ReturnsNull()
        {
            IUserRepository repo = new UserRepository();
            var result = repo.GetUser(Guid.NewGuid());
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllUsers_ReturnsAllUsers()
        {
            IUserRepository repo = new UserRepository();
            var user1 = new FakeUser { id = Guid.NewGuid() };
            var user2 = new FakeUser { id = Guid.NewGuid() };

            repo.AddUser(user1);
            repo.AddUser(user2);

            var result = repo.GetAllUsers();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Exists(u => u.id == user1.id));
            Assert.IsTrue(result.Exists(u => u.id == user2.id));
        }

        [Test]
        public void RemoveUser_ExistingUser_ReturnsTrue()
        {
            IUserRepository repo = new UserRepository();
            var user = new FakeUser { id = Guid.NewGuid() };
            repo.AddUser(user);

            var result = repo.RemoveUser(user.id);

            Assert.IsTrue(result);
            Assert.IsNull(repo.GetUser(user.id));
        }

        [Test]
        public void RemoveUser_NonExisting_ReturnsFalse()
        {
            IUserRepository repo = new UserRepository();
            var result = repo.RemoveUser(Guid.NewGuid());

            Assert.IsFalse(result);
        }
    }
}
