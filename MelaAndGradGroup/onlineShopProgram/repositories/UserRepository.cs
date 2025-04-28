using MelaAndGradGroup.onlineShopProgram;
using MelaAndGradGroup.onlineShopProgram.data;
using MelaAndGradGroup.onlineShopProgram.entities;
using MelaAndGradGroup.onlineShopProgram.repositories;
using Microsoft.EntityFrameworkCore;


public class UserRepository : IUserRepository {

    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> FindByID(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> Save(User entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(User entity)
    {
        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User entity)
    {
        _context.Users.Update(entity); 
        await _context.SaveChangesAsync(); 
    }

    public async Task<List<User>> FindAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> FindByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.username == username);
    }
}
