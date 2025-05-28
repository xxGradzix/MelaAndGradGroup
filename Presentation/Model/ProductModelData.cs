using System;
using Presentation.Model.API;

namespace Presentation.Model
{
    internal class ProductModelData : IProductModelData
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }

        public ProductModelData(Guid id, string name, double price, int quantity, string description)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.description = description;
        }
    }
}