using MelaAndGradGroup.onlineShopProgram;
using MelaAndGradGroup.onlineShopProgram.data;
using MelaAndGradGroup.onlineShopProgram.repositories;
using Microsoft.EntityFrameworkCore;


public class ProductEventRepository : IProductEventRepository {

    private readonly AppDbContext _context;

    public ProductEventRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<ProductEvent>> FindAll()
    {
        return await _context.ProductEvents.ToListAsync();
    }
    public async Task<ProductEvent> FindByID(int id)
    {
        return await _context.ProductEvents.FindAsync(id);
    }

    public async Task<ProductEvent> Save(ProductEvent entity)
    {
        _context.ProductEvents.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Update(ProductEvent user)
    {
        _context.ProductEvents.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(ProductEvent entity)
    {
        if (entity != null)
        {
            _context.ProductEvents.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task Delete(int id)
    {
        var product = await _context.ProductEvents.FindAsync(id);
        Delete(product);
    }

}