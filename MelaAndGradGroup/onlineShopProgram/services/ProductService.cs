
namespace MelaAndGradGroup.onlineShopProgram.services;

public class ProductService {
    
    private ProductRepository repository;
    
    public ProductService(ProductRepository repository)
    {
        this.repository = repository;
    }
    
    public async Task<List<Product>> findAll()
    {
        
        List<Product> products = new List<Product>();
        return products;
    }
    
    
}