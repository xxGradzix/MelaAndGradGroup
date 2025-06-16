using System.ComponentModel.DataAnnotations;

namespace Data.API.Entities
{
    public interface ICatalog
    {
        public int id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        // public int quantity { get; set; }

        public string description { get; set; }
        
    }
}
