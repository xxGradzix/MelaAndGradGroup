using MelaAndGradGroup.onlineShopProgram;
using MelaAndGradGroup.onlineShopProgram.data;
using MelaAndGradGroup.onlineShopProgram.repositories;
using Microsoft.EntityFrameworkCore;


// public class ProductRepository : Repository<Product, int> {
public class ProductRepository : IProductRepository {

    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Product>> findAll()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<Product> findByID(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> save(Product entity)
    {
        _context.Products.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task update(Product user)
    {
        _context.Products.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task delete(Product entity)
    {
        if (entity != null) {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        delete(product);
    }
    
}