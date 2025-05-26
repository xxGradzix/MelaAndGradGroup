using System.ComponentModel.DataAnnotations;
using Data.API.Entities;

namespace Data.Catalog
{
    public class Product : IProduct
    {
        public Guid id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public String name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number")]
        public int quantity { get; set; }

        [StringLength(500)] public String description { get; set; }

        public Product(String name, double price, int quantity, String description)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.description = description;
        }
    }

}