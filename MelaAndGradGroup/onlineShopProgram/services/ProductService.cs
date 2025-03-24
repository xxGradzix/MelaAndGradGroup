

using MelaAndGradGroup.onlineShopProgram.repositories;

namespace MelaAndGradGroup.onlineShopProgram.services;

public class ProductService : IProductService {
    
    private IProductRepository repository;
    
    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }
    
    public async Task<List<Product>> FindAll()
    {
        return await repository.FindAll();
    }
    public async Task<Product> AddProduct(ProductDTO productDTO)
    {
        Product product = new Product(productDTO.name, productDTO.price, productDTO.quantity, productDTO.description);
        return await repository.Save(product);
    }

    public async Task<Product> FindById(int id)
    {
        return await repository.FindByID(id);
    }
}