using Logic.Services;
using Logic.Services.Interfaces;
using Logic.Repositories.Interfaces;
using Data.API.Entities;
using Data.Enums;


namespace LogicTest.ServicesTest
{
    public class UserServiceTest
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

        private class FakeEvent : IEvent
        {
            public Guid eventId { get; } = Guid.NewGuid();
            public DateTime timestamp { get; set; } = DateTime.Now;
        }

        private class FakeUserFactory : IUserFactory
        {
            public IUser CreateUser(string username, string password, string email, string phoneNumber)
            {
                return new FakeUser
                {
                    id = Guid.NewGuid(),
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

            public void AddUser(IUser user) => users[user.id] = user;
            public IUser? GetUser(Guid id) => users.TryGetValue(id, out var u) ? u : null;
            public List<IUser> GetAllUsers() => new(users.Values);
            public bool RemoveUser(Guid id) => users.Remove(id);

            public IUser? FindUserByUsername(string username) =>
            users.Values.FirstOrDefault(u => u.username.Equals(username, StringComparison.OrdinalIgnoreCase));
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
            repo.AddUser(new FakeUser { id = Guid.NewGuid(), username = "testuser" });

            Assert.Throws<InvalidOperationException>(() => service.Register("testuser", "pass123", "example@test.com", "123456789"));
        }

        [Test]
        public void RemoveUser_Success()
        {
            var service = CreateService(out var repo, out var events);
            var id = Guid.NewGuid();
            var user = new FakeUser { id = id, username = "testuser" };
            repo.AddUser(user);

            var result = service.Remove(id);

            Assert.IsTrue(result);
            Assert.IsNull(repo.GetUser(id));
            Assert.AreEqual(1, events.GetAllEvents().Count);
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
            var user = new FakeUser { id = Guid.NewGuid() };
            repo.AddUser(user);

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
            repo.AddUser(new FakeUser { id = Guid.NewGuid() });

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
