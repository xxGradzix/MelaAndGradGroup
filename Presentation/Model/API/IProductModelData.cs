namespace Presentation.Model.API
{
    public interface IProductModelData
    {
        Guid id { get; set; }

        string name { get; set; }

        double price { get; set; }

        int quantity { get; set; }

        string description { get; set; }
    }
}