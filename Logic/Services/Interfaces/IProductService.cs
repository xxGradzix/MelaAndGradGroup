using Data.API.Entities;

namespace Logic.Services.Interfaces
{
    public interface IProductService
    {
        IProduct AddProduct(IProduct iproduct);
        List<IProduct> FindAll();
        IProduct? FindById(Guid id);
        bool DeleteProductById(Guid id);
        IProduct SellProduct(Guid productId, Guid userId, int quantity);
    }
}
