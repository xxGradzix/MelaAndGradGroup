using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.API.Entities
{
    public interface IProduct
    {
        Guid id { get; set; }

        String name { get; set; }
        
        double price { get; set; }
        
        int quantity { get; set; }

        String description { get; set; }

    }

}