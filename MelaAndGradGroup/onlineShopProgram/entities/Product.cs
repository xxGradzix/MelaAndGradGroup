public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }

    public Product() { }

    public Product(string name, double price, int quantity, string description)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Description = description;
    }
}