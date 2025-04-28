

using MelaAndGradGroup.onlineShopProgram.entities.fields;
using MelaAndGradGroup.onlineShopProgram.repositories;
using Microsoft.EntityFrameworkCore;

namespace MelaAndGradGroup.onlineShopProgram.services;

public class ProductService : IProductService {
    
    private IProductRepository repository;
    private IProductEventRepository eventRepository;
    
    public ProductService(IProductRepository repository, IProductEventRepository eventRepository)
    {
        this.repository = repository;
        this.eventRepository = eventRepository;
    }
    
    public async Task<List<Product>> FindAll()
    {
        return await repository.FindAll();
    }
    public async Task<Product> AddProduct(ProductDTO productDTO)
    {
        Product product = new Product(productDTO.name, productDTO.price, productDTO.quantity, productDTO.description);
        //user ktory dodal
        return await repository.Save(product);
    }

    //addNewProductToCatalog
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

    public async Task<Product> UpdateProductById(int id, ProductDTO productDTO) //supplyProductById
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

    public async Task<Product> SellProduct(int productId, int quantity)
    {
        var product = await repository.FindByID(productId);
        if (product == null)
        {
            throw new Exception($"Product with ID {productId} not found.");
        }

        if (product.quantity < quantity)
        {
            throw new Exception($"Not enough quantity in stock. Available: {product.quantity}, Requested: {quantity}");
        }

        product.quantity -= quantity;
        await repository.Update(product);

        var productEvent = new ProductEvent
        {
            productId = (int)product.id,
            EventType = ProductEventType.Sale,
            QuantityChange = -quantity,
            Timestamp = DateTime.UtcNow
        };

        await eventRepository.Save(productEvent);

        return product;
    }

}