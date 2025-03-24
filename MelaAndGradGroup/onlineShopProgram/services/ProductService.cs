

using MelaAndGradGroup.onlineShopProgram.repositories;

namespace MelaAndGradGroup.onlineShopProgram.services;

public class ProductService : IProductService {
    
    // private ProductRepository repository;
    //
    // public ProductService(ProductRepository repository)
    // {
    //     this.repository = repository;
    // }
    
    private IProductRepository repository;
    
    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }
    
    public async Task<List<Product>> findAll()
    {
        return await repository.findAll();
    }
    public async Task<Product> AddProduct(ProductDTO productDTO)
    {
        Product product = new Product(productDTO.name, productDTO.price, productDTO.quantity, productDTO.description);
        return await repository.save(product);
    }

    public async Task<Product> findById(int id)
    {
        return await repository.findByID(id);
    }
}