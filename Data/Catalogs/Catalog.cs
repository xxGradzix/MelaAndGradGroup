using System.ComponentModel.DataAnnotations;
using Data.API.Entities;

namespace Data.Catalogs
{
    public class Catalog: ICatalog
    {
        public int id  { get; set; }
        public string name  { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        
        public Catalog(int id, string name, double price, string description)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.description = description;
        }

        public Catalog() { }
    }
}


