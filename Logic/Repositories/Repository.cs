using Data.API;
using Data.API.Entities;
using Logic.Repositories.Interfaces;

namespace Logic.Repositories
{
    public class Repository : IRepository
    {
        IData context;
        public Repository(IData context)
        {
            this.context = context;
        }

        //public IProduct? GetProduct(Guid id)
        //{
        //    return items.Find(i => i.id == id);
        //}

        //public List<IProduct> GetAllProducts()
        //{
        //    return new List<IProduct>(items);
        //}

        //public bool RemoveProduct(Guid id)
        //{
        //    return items.RemoveAll(i => i.id == id) > 0;
        //}

        public void BuyCatalog(int stateId, int userId)
        {
            context.ChangeState(stateId, -1);
            context.AddUserEvent(stateId, userId);
        }

        public void SellCatalog(int stateId, int userId)
        {
            context.ChangeState(stateId, 1);
            context.AddUserEvent(stateId, userId);
        }

        public void RemoveCatalog(int stateId)
        {
            context.ChangeState(stateId, -1);
            context.AddDatabaseEvent(stateId);
        }

        public void AddCatalog(int stateId)
        {
            context.ChangeState(stateId, 1);
            context.AddDatabaseEvent(stateId);
        }

        public void AddNewCatalogType(string name, double price, string description)
        {
            context.AddCatalog(name, price, description);
        }
    }
}
