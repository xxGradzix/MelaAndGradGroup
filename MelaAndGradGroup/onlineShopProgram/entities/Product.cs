//using System.Text.Json.Serialization;

using System.Text.Json.Serialization;

public class Product
{
    public int? id { get; set; }
    public String name { get; set; }
    public double price { get; set; }
    public int quantity { get; set; }
    public String description { get; set; }

    public Product() { }

    public Product(String name, double price, int quantity, String description)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.description = description;
    }

    [JsonIgnore]
    public ExecutionContext Context { get; set; }
}