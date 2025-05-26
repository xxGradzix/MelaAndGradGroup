using Logic.Services;
using Logic.Services.Interfaces;
using Data.Repositories.Interfaces;
using Data.API.Entities;
using Data.Enums;
using Data.Events;
using Data.Users;


namespace LogicTest.ServicesTest
{
    public class UserServiceTest
    {

        private class FakeUser : User
        {
            public FakeUser() : base("username", "email", "password", "phoneNumber", Role.USER)
            {
            }

        }

        private class FakeEvent : Event
        {
        }

        private class FakeUserFactory : IUserFactory
        {
            public IUser CreateUser(string username, string password, string email, string phoneNumber)
            {
                return new FakeUser
                {
                    username = username,
                    password = password,
                    email = email,
                    phoneNumber = phoneNumber,
                    role = Role.USER
                };
            }
        }

        private class FakeUserRepo : IUserRepository
        {
            private readonly Dictionary<Guid, IUser> users = new();


            public IUser? FindUserByUsername(string username) =>
                users.Values.FirstOrDefault(u => u.username.Equals(username, StringComparison.OrdinalIgnoreCase));

            public User? FindByID(Guid id)
            {
                return users.TryGetValue(id, out var u) ? (User)u : null;
            }

            public User Save(User entity)
            {
                if (users.ContainsKey(entity.id))
                {
                    throw new InvalidOperationException("User already exists");
                }
                users[entity.id] = entity;
                return entity;
            }

            public bool Delete(User entity)
            {
                if (users.ContainsKey(entity.id))
                {
                    users.Remove(entity.id);
                    return true;
                }
                return false;
            }

            public bool Delete(Guid id)
            {
                return users.Remove(id);
            }

            public User Update(User entity)
            {
                if (users.ContainsKey(entity.id))
                {
                    users[entity.id] = entity;
                    return entity;
                }
                throw new InvalidOperationException("User not found");
            }

            public List<User> FindAll()
            {
                return users.Values.Cast<User>().ToList();
            }
        }

        private class FakeEventService : IEventService
        {
            public List<IEvent> Events { get; } = new();
            public bool AddEvent(IEvent eventBase)
            {
                Events.Add(eventBase);
                return true;
            }
            public List<IEvent> GetAllEvents() => new(Events);
        }

        private class FakeEventFactory : IEventFactory
        {
            public IEvent CreateUserAddedEvent(Guid userId, string userEmail) => new FakeEvent();
            public IEvent CreateNewUserAddedEvent(Guid userId, string userEmail) => new FakeEvent();
            public IEvent CreateUserRemovedEvent(Guid userId) => new FakeEvent();

            public IEvent CreateProductBoughtEvent(Guid userId, Guid productId, int quantity) => new FakeEvent();
            public IEvent CreateProductAddedEvent(Guid productId, int quantity) => new FakeEvent();
            public IEvent CreateProductRemovedEvent(Guid productId) => new FakeEvent();
            public IEvent CreateSellProductEvent(Guid userId, Guid itemId, int quantity) => new FakeEvent();
        }

        private UserService CreateService(out FakeUserRepo repo, out FakeEventService events)
        {
            repo = new FakeUserRepo();
            events = new FakeEventService();
            return new UserService(repo, events, new FakeEventFactory(), new FakeUserFactory());
        }

        [Test]
        public void AddUser_Success()
        {
            var service = CreateService(out var repo, out var events);
            
            String username = "testuser";
            String password = "pass123";
            String email = "example@test.com";
            String phoneNumber = "123456789";

            var result = service.Register(username, password, email, phoneNumber);

            Assert.IsNotNull(result);
            Assert.AreEqual(username, result.username);
            Assert.AreEqual(1, events.GetAllEvents().Count);
            
        }

        [Test]
        public void AddUser_DuplicateId_Throws()
        {
            var service = CreateService(out var repo, out _);
            var fakeUser = new FakeUser { };
            repo.Save(fakeUser);

            Assert.Throws<InvalidOperationException>(() => service.Register(fakeUser.username, "pass123", "example@test.com", "123456789"));
        }

        [Test]
        public void RemoveUser_Success()
        {
            var service = CreateService(out var repo, out var events);
            var id = Guid.NewGuid();
            var user = new FakeUser { };
            repo.Save(user);

            var result = service.Remove(id);

            Assert.IsFalse(result);
            Assert.IsNull(repo.FindByID(id));
            Assert.AreEqual(0, events.GetAllEvents().Count);
        }

        [Test]
        public void RemoveUser_NotFound_ReturnsFalse()
        {
            var service = CreateService(out _, out var events);

            var result = service.Remove(Guid.NewGuid());

            Assert.IsFalse(result);
            Assert.AreEqual(0, events.GetAllEvents().Count);
        }

        [Test]
        public void GetUser_Existing_ReturnsUser()
        {
            var service = CreateService(out var repo, out _);
            var user = new FakeUser { };
            repo.Save(user);

            var result = service.GetById(user.id);

            Assert.AreEqual(user, result);
        }

        [Test]
        public void GetUser_NotFound_Throws()
        {
            var service = CreateService(out _, out _);
            Assert.Throws<InvalidOperationException>(() => service.GetById(Guid.NewGuid()));
        }

        [Test]
        public void GetAllUsers_ReturnsUsers()
        {
            var service = CreateService(out var repo, out _);
            repo.Save(new FakeUser { });

            var result = service.FindAll();

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllUsers_Empty_Throws()
        {
            var service = CreateService(out _, out _);
            Assert.Throws<InvalidOperationException>(() => service.FindAll());
        }

    }
}
