

using MelaAndGradGroup.onlineShopProgram.entities;
using MelaAndGradGroup.onlineShopProgram.repositories;
using Microsoft.EntityFrameworkCore;

namespace MelaAndGradGroup.onlineShopProgram.services;

public class UserService : IUserService
{
    private readonly IUserRepository repository;

    public UserService(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<List<User>> FindAll()
    {
        return await repository.FindAll();
    }

    public async Task<User> Register(UserDTO userDTO)
    {
        User user = new User(userDTO.username, userDTO.password);
        return await repository.Save(user);

    }
    public async Task<bool> Login(string username, string password)
    {
        var user = await repository.FindByUsername(username);
        return user != null && user.password == password; 
    }

}