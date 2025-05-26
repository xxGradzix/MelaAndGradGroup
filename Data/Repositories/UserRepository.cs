
using Data.API.Entities;
using Data.dataContextImpl.database;
using Data.Repositories.Interfaces;
using Data.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User FindByID(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User Save(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(User entity)
        {
            if (entity != null)
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool Delete(Guid id)
        {
            User product = _context.Users.Find(id);
            return Delete(product);

        }

        public User Update(User entity)
        {
            _context.Users.Update(entity); 
            _context.SaveChanges();
            return entity;
        }

        public List<User> FindAll()
        {
            return _context.Users.ToList();
        }

        public IUser? FindUserByUsername(string username)
        {
            return FindByUsername(username);
        }

        public User FindByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.username == username);
        }
    }
}
