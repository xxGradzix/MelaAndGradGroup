using Data.API.Entities;
using Data.Users;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        IUser? FindUserByUsername(string username);
    }
}
