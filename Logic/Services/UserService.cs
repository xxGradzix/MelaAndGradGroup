using Data.API.Entities;
using Data.Repositories.Interfaces;
using Data.Users;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IEventService eventService;
        private readonly IEventFactory eventFactory;
        private readonly IUserFactory userFactory;

        public UserService(IUserRepository repository, IEventService eventService, IEventFactory eventFactory, IUserFactory userFactory)
        {
            this.userRepository = repository;
            this.eventService = eventService;
            this.eventFactory = eventFactory;
            this.userFactory = userFactory;
        }

        public bool Remove(Guid id)
        {
            var user = userRepository.FindByID(id);
            if (user == null)
            {
                return false;
            }
            eventService.AddEvent(eventFactory.CreateUserRemovedEvent(user.id));
            return userRepository.Delete(id);
        }

        public IUser GetById(Guid id)
        {
            var user = userRepository.FindByID(id);
            if (user == null)
            {
                throw new InvalidOperationException("Error, no user with such id.");
            }
            return user;
        }

        public List<IUser> FindAll()
        {
            var users = userRepository.FindAll();
            if (users.Count == 0)
            {
                throw new InvalidOperationException("Error, no users found.");
            }
            return users.Cast<IUser>().ToList();
        }

        public IUser Register(string username, string password, string email, string phonenumber)
        {
            var user = userRepository.FindAll().Cast<IUser>().FirstOrDefault(u => u.username == username);
            
            if (user != null)
            {
                throw new InvalidOperationException("Error, User iwth this username already exists.");
            }

            user = userFactory.CreateUser(username, password, email, phonenumber);
            userRepository.Save((User)user);
            eventService.AddEvent(eventFactory.CreateUserAddedEvent(user.id, user.username));
            return user;
        }

        public bool Login(string username, string password)
        {
            IUser? user = userRepository.FindUserByUsername(username);
            return user != null && user.password == password;
        }
    }
}
