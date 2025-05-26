using Data.API.Entities;
using Data.Catalog;
using Data.dataContextImpl.database;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository {

        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Product> FindAll()
        {
            return _context.Products.ToList();
        }
        public Product FindByID(Guid id)
        {
            return _context.Products.Find(id);
        }

        public Product Save(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Product Update(Product user)
        {
            _context.Products.Update(user);
            _context.SaveChanges();
            return user;
        }

        public bool Delete(Product entity)
        {
            if (entity != null) {
                _context.Products.Remove(entity);
                _context.SaveChanges();
               return true;
            }

            return false;
        }
        public bool Delete(Guid id)
        {
            Product product = _context.Products.Find(id);
            return Delete(product);
            
        }
    
    }
}
