using Data.API;
using Data.API.Entities;
using Logic.Repositories;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    internal sealed class DataService : IDataService
    {
        static IData context = default(IData);
        static Repository repository = new Repository(context);

        public void BuyCatalog(int StateId, int UserId)
        {
            repository.BuyCatalog(StateId, UserId);
        }

        public void SellCatalog(int StateId, int UserId)
        {
            repository.SellCatalog(StateId, UserId);
        }

        public void RemoveCatalog(int StateId)
        {
            repository.RemoveCatalog(StateId);
        }

        public void AddCatalog(int StateId)
        {
            repository.AddCatalog(StateId);
        }
    }
}
