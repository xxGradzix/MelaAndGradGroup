
public class ProductDTO
{
    public String name { get; set; }
    public double price { get; set; }
    public int quantity { get; set; }
    public String description { get; set; }

    public ProductDTO(String name, double price, int quantity, String description)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.description = description;
    }


}
