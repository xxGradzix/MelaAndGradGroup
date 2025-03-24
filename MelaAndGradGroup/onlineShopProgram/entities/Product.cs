using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Product
{
    public int? id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public String name { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public double price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number")]
    public int quantity { get; set; }

    [StringLength(500)]
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
    [NotMapped]
    public ExecutionContext Context { get; set; } 
}