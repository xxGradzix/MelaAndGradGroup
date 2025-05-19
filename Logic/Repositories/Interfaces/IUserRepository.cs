using Data.API.Entities;

namespace Logic.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(IUser user);
        IUser? GetUser(Guid id);
        List<IUser> GetAllUsers();
        bool RemoveUser(Guid id);
        IUser? FindUserByUsername(string username);
    }
}
