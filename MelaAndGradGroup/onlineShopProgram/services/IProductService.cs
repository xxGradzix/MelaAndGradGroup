namespace MelaAndGradGroup.onlineShopProgram.services;

public interface IProductService
{

    public Task<List<Product>> FindAll();

    public Task<Product> AddProduct(ProductDTO productDTO);

    public Task<Product> FindById(int id);

    public Task<bool> DeleteProductById(int id);

    public Task<Product> UpdateProductById(int id, ProductDTO productDTO);

}