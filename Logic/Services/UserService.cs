using Data.API.Entities;
using Logic.Repositories.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IEventService eventService;
        private readonly IEventFactory eventFactory;
        private readonly IUserFactory userFactory;

        internal UserService(IUserRepository repository, IEventService eventService, IEventFactory eventFactory, IUserFactory userFactory)
        {
            this.userRepository = repository;
            this.eventService = eventService;
            this.eventFactory = eventFactory;
            this.userFactory = userFactory;
        }

        public bool Remove(Guid id)
        {
            var user = userRepository.GetUser(id);
            if (user == null)
            {
                return false;
            }
            eventService.AddEvent(eventFactory.CreateUserRemovedEvent(user.id));
            return userRepository.RemoveUser(id);
        }

        public IUser GetById(Guid id)
        {
            var user = userRepository.GetUser(id);
            if (user == null)
            {
                throw new InvalidOperationException("Error, no user with such id.");
            }
            return user;
        }

        public List<IUser> FindAll()
        {
            var users = userRepository.GetAllUsers();
            if (users.Count == 0)
            {
                throw new InvalidOperationException("Error, no users found.");
            }
            return users;
        }

        public IUser Register(string username, string password, string email, string phonenumber)
        {
            try
            {
                var user = userRepository.GetAllUsers().FirstOrDefault(u => u.username == username);
                if (user != null)
                {
                    throw new InvalidOperationException("Error, User iwth this username already exists.");
                }

                userFactory.CreateUser(username, password, email, phonenumber);
                userRepository.AddUser(user);
                eventService.AddEvent(eventFactory.CreateUserAddedEvent(user.id, user.username));
                return user;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"{e.Message}");
                return null;
            }
        }

        public bool Login(string username, string password)
        {
            IUser? user = userRepository.FindUserByUsername(username);
            return user != null && user.password == password;
        }
    }
}
