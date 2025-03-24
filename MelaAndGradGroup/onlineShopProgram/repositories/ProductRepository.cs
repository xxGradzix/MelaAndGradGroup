using MelaAndGradGroup.onlineShopProgram;
using MelaAndGradGroup.onlineShopProgram.data;
using Microsoft.EntityFrameworkCore;


public class ProductRepository : Repository<Product, int> {

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

    public async Task save(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
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