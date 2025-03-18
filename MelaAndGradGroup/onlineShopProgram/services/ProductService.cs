namespace MelaAndGradGroup.onlineShopProgram.services;

public class ProductService
{
    private ProductRepository repository;


    public ProductService(ProductRepository repository)
    {
        this.repository = repository;
    }
    
    
}