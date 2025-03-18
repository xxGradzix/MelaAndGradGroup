namespace MelaAndGradGroup.onlineShopProgram.entities;

public class Product
{
    private Guid id;
    private string name;
    private double price;
    private int quantity;
    private string description;
    
    public Product(string name, double price, int quantity, string description)
    {
        this.id = Guid.NewGuid();
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.description = description;
    }
}