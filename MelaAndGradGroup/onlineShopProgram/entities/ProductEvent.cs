using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MelaAndGradGroup.onlineShopProgram.entities.fields;

public class ProductEvent
{
    public int? id { get; set; }
    public int productId { get; set; }
    public ProductEventType EventType { get; set; }
    public int QuantityChange { get; set; } 

    public DateTime Timestamp { get; set; }

}
