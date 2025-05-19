using Data.API.Entities;
using Logic.Repositories.Interfaces;

namespace Logic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<IProduct> items = new();

        public void SaveProduct(IProduct product)
        {
            items.Add(product);
        }

        public IProduct? GetProduct(Guid id)
        {
            return items.Find(i => i.id == id);
        }

        public List<IProduct> GetAllProducts()
        {
            return new List<IProduct>(items);
        }

        public bool RemoveProduct(Guid id)
        {
            return items.RemoveAll(i => i.id == id) > 0;
        }
    }
}
