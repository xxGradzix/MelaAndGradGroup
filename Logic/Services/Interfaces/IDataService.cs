using Data.API.Entities;

namespace Logic.Services.Interfaces
{
    public interface IDataService
    {
        public abstract void BuyCatalog(int StateId, int UserId);
        public abstract void SellCatalog(int StateId, int UserId);
        public abstract void RemoveCatalog(int StateId);
        public abstract void AddCatalog(int StateId);
    }
}
