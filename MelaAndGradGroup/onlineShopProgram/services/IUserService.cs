using MelaAndGradGroup.onlineShopProgram.entities;

namespace MelaAndGradGroup.onlineShopProgram.services;

public interface IUserService
{
    public Task<User> Register(UserDTO userDTO);

    public Task<bool> Login(string username, string password);

    public Task<List<User>> FindAll();
}