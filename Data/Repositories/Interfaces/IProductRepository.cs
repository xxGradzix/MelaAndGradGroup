using Data.API.Entities;
using Data.Catalog;

namespace Data.Repositories.Interfaces

{
    public interface IProductRepository : IRepository<Product, Guid>
    {
    }
}
