using MelaAndGradGroup.onlineShopProgram.entities;

namespace MelaAndGradGroup.onlineShopProgram.repositories;

public interface IUserRepository : Repository<User, int>
{
    Task<User> FindByUsername(string username);
}