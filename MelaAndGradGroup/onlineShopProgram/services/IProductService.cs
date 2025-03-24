namespace MelaAndGradGroup.onlineShopProgram.services;

public interface IProductService
{

    public Task<List<Product>> findAll();

    public Task<Product> AddProduct(ProductDTO productDTO);

    public Task<Product> findById(int id);
}