using Data.Repositories;
using Data.Repositories.Interfaces;
using Data.dataContextImpl.database;
using Data.Enums;
using Data.Users;
using Microsoft.EntityFrameworkCore;


namespace LogicTest.RepositoriesTest
{
    public class UserRepositoryTest
    {
        private DbContextOptions<AppDbContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        private UserRepository GetRepo()
        {
            var options = GetInMemoryOptions();
            var context = new AppDbContext(options);
            return new UserRepository(context);
        }
        
        private class FakeUser : User
        {
            
            public FakeUser() : base("username", "email", "password", "phoneNumber", Role.USER)
            {
                this.username = username;
                this.password = password;
                this.email = email;
                this.phoneNumber = phoneNumber;
                this.role = role;
            }

        }

        [Test]
        public void AddUser_ShouldStoreUser()
        {
            UserRepository repo = GetRepo();
            var user = new FakeUser { email = "example @email.com" };

            repo.Save(user);
            var result = repo.FindByID(user.id);

            Assert.IsNotNull(result);
            Assert.AreEqual(user.id, result!.id);
        }

        [Test]
        public void GetUser_NotFound_ReturnsNull()
        {
            IUserRepository repo = GetRepo();
            var result = repo.FindByID(Guid.NewGuid());
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllUsers_ReturnsAllUsers()
        {
            IUserRepository repo = GetRepo();
            var user1 = new FakeUser {  };
            var user2 = new FakeUser {  };

            repo.Save(user1);
            repo.Save(user2);

            var result = repo.FindAll();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Exists(u => u.id == user1.id));
            Assert.IsTrue(result.Exists(u => u.id == user2.id));
        }

        [Test]
        public void RemoveUser_ExistingUser_ReturnsTrue()
        {
            IUserRepository repo = GetRepo();
            var user = new FakeUser { };
            repo.Save(user);

            var result = repo.Delete(user.id);

            Assert.IsTrue(result);
            Assert.IsNull(repo.FindByID(user.id));
        }

        [Test]
        public void RemoveUser_NonExisting_ReturnsFalse()
        {
            IUserRepository repo = GetRepo();
            var result = repo.Delete(Guid.NewGuid());

            Assert.IsFalse(result);
        }
    }
}
