

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

        Product product = new Product("test", 0.5, 1, "test");
        products.Add(product);
        
        return products;
    }

    public Task AddProduct(ProductDTO productDTO)
    {
        Product product = new Product(productDTO.name, productDTO.price, productDTO.quantity, productDTO.description);
        return repository.save(product);
    }
}