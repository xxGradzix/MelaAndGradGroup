

using MelaAndGradGroup.onlineShopProgram.repositories;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> DeleteProductById(int id)
    {
        var product = await repository.FindByID(id);
        if (product == null)
        {
            return false;
        }
        await repository.Delete(product);
        return true;
    }

    public async Task<Product> UpdateProductById(int id, ProductDTO productDTO)
    {
        var product = await repository.FindByID(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product with ID " + id + " not found.");
        }

        product.name = productDTO.name;
        product.price = productDTO.price;
        product.quantity = productDTO.quantity;
        product.description = productDTO.description;

        await repository.Update(product);

        return product;
    }
}