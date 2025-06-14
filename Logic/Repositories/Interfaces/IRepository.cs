
namespace Logic.Repositories.Interfaces
{
    public interface IRepository//<T, ID> where T : class
    {
        //Task<T> FindByID(ID id);
        //Task<T> Save(T entity);
        //Task Delete(T entity);
        //Task Update(T entity);
        //Task<List<T>> FindAll();
        public abstract void BuyCatalog(int stateId, int userId);

        public abstract void SellCatalog(int stateId, int userId);

        public abstract void RemoveCatalog(int stateId);

        public abstract void AddCatalog(int stateId);

        public abstract void AddNewCatalogType(string name, double price, string description);

    }
    
}
    
