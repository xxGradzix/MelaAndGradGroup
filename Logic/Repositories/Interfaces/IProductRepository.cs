using Data.API.Entities;
namespace Logic.Repositories.Interfaces

{
    public interface IProductRepository
    {
        void SaveProduct(IProduct product);
        bool RemoveProduct(Guid Id);
        IProduct? GetProduct(Guid Id);
        List<IProduct> GetAllProducts();
    }
}
